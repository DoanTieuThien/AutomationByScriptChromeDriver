using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FormAutomationChromeByScript
{
    public partial class FormAutomationByScript : Form
    {
        private List<String> mlsScriptAction = null;
        private AutoCompleteStringCollection col = null;

        public FormAutomationByScript()
        {
            InitializeComponent();
            this.mlsScriptAction = new List<string>();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            loadScript();
        }

        private void startAction()
        {
            ThreadStart threadStart = new ThreadStart(executAction);
            Thread thread = new Thread(threadStart);

            thread.IsBackground = true;
            thread.Start();
        }
        private void executAction()
        {
            ScriptControlAction scriptControlAction = new ScriptControlAction();

            try
            {
                invokeAppendText(this.txtLogAction, "Starting execute script\r\n");
                foreach (String action in this.mlsScriptAction)
                {
                    if (action.StartsWith(ScriptMessage.ACTION_LOAD_URL_PROP))
                    {
                        String url = action.Split('=')[1];

                        invokeAppendText(this.txtLogAction, "Loading website " + url + "\r\n");
                        scriptControlAction.actionLoadUrl(url);
                        invokeAppendText(this.txtLogAction, "Loading website " + url + " successfull\r\n");
                    }
                    else if (action.StartsWith(ScriptMessage.ACTION_CLICK_ID_PROP))
                    {
                        invokeAppendText(this.txtLogAction, "Click element by id \r\n");
                        scriptControlAction.actionClickID(action);
                        invokeAppendText(this.txtLogAction, "Click element by id successfull \r\n");
                    }
                    else if (action.StartsWith(ScriptMessage.ACTION_CLICK_CLASS_PROP))
                    {
                        invokeAppendText(this.txtLogAction, "Click element by class name \r\n");
                        scriptControlAction.actionClickClassName(action);
                        invokeAppendText(this.txtLogAction, "Click element by class name successfull \r\n");
                    }
                    else if (action.StartsWith(ScriptMessage.ACTION_CLOSE_BROWSER_PROP))
                    {
                        String actionCloseBrowser = action.Split('=')[1].Trim();

                        if ("TRUE".Equals(actionCloseBrowser.ToUpper()))
                        {
                            invokeAppendText(this.txtLogAction, "Closing website\r\n");
                            scriptControlAction.closeBrowser();
                            invokeAppendText(this.txtLogAction, "Close website successfull\r\n");
                        }
                    }
                    else if (action.StartsWith(ScriptMessage.ACTION_GET_CLASS_PROP))
                    {
                        invokeAppendText(this.txtLogAction, "Getting element by class name \r\n");
                        String attributeData = scriptControlAction.actionGetByClassName(action);
                        invokeAppendText(this.txtLogAction, "Getting element value " + attributeData + "\r\n");
                    }
                    else if (action.StartsWith(ScriptMessage.ACTION_GET_ID_PROP))
                    {
                        invokeAppendText(this.txtLogAction, "Getting element by id \r\n");
                        String attributeData = scriptControlAction.actionGetID(action);
                        invokeAppendText(this.txtLogAction, "Getting element value " + attributeData + "\r\n");
                    }
                    else if (action.StartsWith(ScriptMessage.ACTION_SET_CLASS_PROP))
                    {
                        invokeAppendText(this.txtLogAction, "Setting element by class name \r\n");
                        scriptControlAction.actionSetByClassName(action);
                        invokeAppendText(this.txtLogAction, "Setting element by class name successfull \r\n");
                    }
                    else if (action.StartsWith(ScriptMessage.ACTION_SET_ID_PROP))
                    {
                        invokeAppendText(this.txtLogAction, "Set element by id \r\n");
                        scriptControlAction.actionSetByID(action);
                        invokeAppendText(this.txtLogAction, "Set element by id successfull\r\n");
                    }
                }
            }catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void invokeAppendText(TextBox t, String s)
        {
            if (t.InvokeRequired)
            {
                t.Invoke(new Action<TextBox, String>(invokeAppendText), new object[]{ t, s });
            }
            else
            {
                t.AppendText(s);
            }
        }
        private void loadScript()
        {
            try
            {
                this.mlsScriptAction.Clear();
                String[] lines = this.txtScript.Lines;

                if(lines == null || lines.Count() == 0)
                {
                    MessageBox.Show("No script is found, please input script again. Thank you!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtScript.Focus();
                    return;
                }

                foreach (String l in lines)
                {
                    String keyProp = null;

                    if(!checkKeyScript(l, out keyProp))
                    {
                        throw new Exception("Script format is wrong with key " + l);
                    }
                    this.mlsScriptAction.Add(l);
                }
                startAction();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean checkKeyScript(String inputKey, out String messagse)
        {
            messagse = null;
            Boolean blResult = false;
            var fieldValues = typeof(ScriptMessage).GetFields()
                     .Select(field => field.GetValue(typeof(ScriptMessage)))
                     .ToList();

            foreach(String filed in fieldValues)
            {
                if (inputKey != null && inputKey.StartsWith(filed)) {
                    messagse = filed;
                    blResult = true;
                    break;
                }
            }
            return blResult;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            this.txtLogAction.Clear();
        }

        private void FormAutomationByScript_Load(object sender, EventArgs e)
        {
            this.txtScript.AutoCompleteMode = AutoCompleteMode.Append;
            this.txtScript.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var fieldValues = typeof(ScriptMessage).GetFields()
                   .Select(field => field.GetValue(typeof(ScriptMessage)))
                   .ToList();
            this.col = new AutoCompleteStringCollection();

            foreach (String filed in fieldValues)
            {
                col.Add(filed);
            }
        }

        private void txtScript_TextChanged(object sender, EventArgs e)
        {
            this.txtScript.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtScript.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtScript.AutoCompleteCustomSource = this.col;
        }
    }

    public class ScriptMessage
    {
        public static String ACTION_LOAD_URL_PROP = "action.load.url";
        public static String ACTION_GET_ID_PROP = "action.get.id";
        public static String ACTION_GET_CLASS_PROP = "action.get.class";
        public static String ACTION_SET_ID_PROP = "action.set.id";
        public static String ACTION_SET_CLASS_PROP = "action.set.class";
        public static String ACTION_CLICK_ID_PROP = "action.click.id";
        public static String ACTION_CLICK_CLASS_PROP = "action.click.class";
        public static String ACTION_CLOSE_BROWSER_PROP = "action.browser.close";
    }

    public class ScriptControlAction
    {
        private ChromeDriverService chromeDriverService = null;
        private ChromeDriver driver = null;

        public void actionLoadUrl(String url)
        {
            try
            {
                chromeDriverService = ChromeDriverService.CreateDefaultService(@"E:\ChromeAuto\ChromeDriver\packages\Selenium.WebDriver.ChromeDriver.2.41.0\driver\win32\", "chromedriver.exe");
                chromeDriverService.HideCommandPromptWindow = true;
                driver = new ChromeDriver(chromeDriverService, new ChromeOptions());
                driver.Navigate().GoToUrl(url);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public String actionGetID(String keyMessage)
        {
            String dataAttribute = null;

            try
            {
                String[] arrayValue = keyMessage.Split('=');
                String idTagName = arrayValue[0].Replace(ScriptMessage.ACTION_GET_ID_PROP, "").Substring(1).Trim();

                if("".Equals(idTagName))
                {
                    throw new Exception("ID can not be null in action Get element by ID of tagname");
                }

                dataAttribute = getAttributeByID(idTagName, arrayValue[1]);
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataAttribute;
        }

        public void actionClickID(String keyMessage)
        {
            try
            {
                String[] arrayValue = keyMessage.Split('=');
                String idTagName = arrayValue[1].Trim();

                if ("".Equals(idTagName) && !arrayValue[0].Equals(ScriptMessage.ACTION_CLICK_ID_PROP))
                {
                    throw new Exception("ID can not be null in action Click element by ID of tagname");
                }

                clickElementByID(idTagName);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void actionSetByID(String keyMessage)
        {
            try
            {
                String[] arrayValue = keyMessage.Split('=');
                String value = arrayValue[1].Trim();
                String valueTemp = arrayValue[0].Replace(ScriptMessage.ACTION_SET_ID_PROP, "").Substring(1);
                String[] arrayValueTemp = valueTemp.Split('.');
                String id = arrayValueTemp[0];
                String attribute = arrayValueTemp[1];

                if ("".Equals(value) && !arrayValue[0].Equals(ScriptMessage.ACTION_SET_ID_PROP))
                {
                    throw new Exception("ID can not be null in action Set element by ID of tagname");
                }
                setValueByID(id, value);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void actionClickClassName(String keyMessage)
        {
            try
            {
                String[] arrayValue = keyMessage.Split('=');
                String classTagName = arrayValue[1].Trim();
                String position = arrayValue[0].Replace(ScriptMessage.ACTION_CLICK_CLASS_PROP, "").Substring(1).Trim();

                if ("".Equals(classTagName) && !arrayValue[0].StartsWith(ScriptMessage.ACTION_CLICK_CLASS_PROP))
                {
                    throw new Exception("Class can not be null in action Click element by class name of tagname");
                }

                clickElementByClass(position,classTagName);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void actionSetByClassName(String keyMessage)
        {
            try
            {
                String[] arrayValue = keyMessage.Split('=');
                String value = arrayValue[1].Trim();
                String valueTemp = arrayValue[0].Replace(ScriptMessage.ACTION_SET_CLASS_PROP, "").Substring(1);
                String[] arrayValueTemp = valueTemp.Split('.');
                String className = arrayValueTemp[0];
                String position = arrayValueTemp[1];

                if ("".Equals(value) && !arrayValue[0].Equals(ScriptMessage.ACTION_SET_ID_PROP))
                {
                    throw new Exception("ID can not be null in action Set element by ID of tagname");
                }
                setValueByClass(className, position, value);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public String actionGetByClassName(String keyMessage)
        {
            String dataAttribute = null;

            try
            {
                String[] arrayValue = keyMessage.Split('=');
                String attribute = arrayValue[1].Trim();
                String valueTemp = arrayValue[0].Replace(ScriptMessage.ACTION_SET_CLASS_PROP, "").Substring(1);
                String[] arrayValueTemp = valueTemp.Split('.');
                String className = arrayValueTemp[0];
                String position = arrayValueTemp[1];

                dataAttribute = getAttributeByClass(className, position, attribute);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataAttribute;
        }

        private String getAttributeByClass(String className, String position, String attributeName)
        {
            String dataAttribute = null;
            ReadOnlyCollection<IWebElement> elementCollections = this.driver.FindElementsByClassName(className);

            if (elementCollections != null)
            {
                int i = 1;
                foreach (IWebElement element in elementCollections)
                {
                    if (Convert.ToString(i).Equals(position))
                    {
                        dataAttribute = element.GetAttribute(attributeName).ToString();
                        break;
                    }
                    i++;
                }
            }
            return dataAttribute;
        }

        private void setValueByClass(String className, String position,String value)
        {
            ReadOnlyCollection<IWebElement> elementCollections = this.driver.FindElementsByClassName(className);

            if (elementCollections != null)
            {
                int i = 1;
                foreach (IWebElement element in elementCollections)
                {
                    if (Convert.ToString(i).Equals(position))
                    {
                        element.SendKeys(value);
                        break;
                    }
                    i++;
                }
            }
        }

        private String getAttributeByID(String idTagName, String attributeName)
        {
            String data = null;
            IWebElement element = this.driver.FindElementById(idTagName);

            if (element != null)
            {
                data = element.GetAttribute(attributeName).ToString();
            }
            return data;
        }

        private void clickElementByID(String idTagName)
        {
            IWebElement element = this.driver.FindElementById(idTagName);

            if (element != null)
            {
                element.Click();
            }

        }

        private void clickElementByClass(String position, String className)
        {
            ReadOnlyCollection<IWebElement> elementCollections = this.driver.FindElementsByClassName(className);

            if (elementCollections != null)
            {
                int i = 1;
                foreach (IWebElement element in elementCollections)
                {
                    if (Convert.ToString(i).Equals(position))
                    {
                        element.Click();
                        break;
                    }
                    i++;
                }
            }
        }

        private void setValueByID(String id, String value)
        {
            IWebElement element = this.driver.FindElementById(id);

            if (element != null)
            {
                element.SendKeys(value);
            }
        }
        public void closeBrowser()
        {
            if (this.driver != null)
            {
                try
                {
                    this.driver.Close();
                }
                catch
                {

                }
            }
            if (this.chromeDriverService != null)
            {
                try
                {
                    this.chromeDriverService.Dispose();
                }
                catch
                {

                }
            }
        }
    }
}
