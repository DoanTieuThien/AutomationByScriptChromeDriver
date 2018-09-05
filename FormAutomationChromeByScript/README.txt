Phần demo thực hiện tự động hóa theo script sử dụng chrome driver bao gồm những phần chính như sau:

1. Key cấu hình sử dụng:
		public static String ACTION_LOAD_URL_PROP = "action.load.url";
        public static String ACTION_GET_ID_PROP = "action.get.id";
        public static String ACTION_GET_CLASS_PROP = "action.get.class";
        public static String ACTION_SET_ID_PROP = "action.set.id";
        public static String ACTION_SET_CLASS_PROP = "action.set.class";
        public static String ACTION_CLICK_ID_PROP = "action.click.id";
        public static String ACTION_CLICK_CLASS_PROP = "action.click.class";
        public static String ACTION_CLOSE_BROWSER_PROP = "action.browser.close";
	Những key ở trên sử dụng để cấu hình script với cấu trúc như sau:

	action.load.url=Địa chỉ website //mục đích là load website theo cấu hình

	//phần này sẽ giúp người dùng cấu hình Get Attribute của TagName theo cấu trúc bên dưới
	action.get.id.Tên_ID_TagName= outerHTMl | innerHTML | innerText | value | style.. 

	//phần này sẽ giúp người dùng lấy thông tin TagName dựa vào vị trí của class
	action.get.class.Vị_trí_class.Class_Name=outerHTMl | innerHTML | innerText | value | style.. 

	//cấu hình set value cho tagname html
	action.set.id.Tên_ID.value=Giá trị muốn set

	//cấu hình set value cho tagname html dựa vào vị trí của tagname với class name tương ứng
	action.set.class.Vị_trí.class_name.value=Giá trị muốn set

	//click tagnem theo ID
	action.click.id=Tên ID

	//click tagnem theo vị trí thẻ chứa class name tương ứng
	action.click.class.Vị_trí=class name

	//Đóng trình duyệt sau khi thực hiện theo kịch bản
	action.browser.close= TRUE | FALSE

2. Mục đích của demo
- Demo này sẽ hình thành cung cấp cho các bạn basic khi muốn tương tác hay tạo ra các kịch bản sử dụng những action cơ bản được cung cấp.

3. Góp ý:
Mọi góp ý xin gửi qua email: tieuthiendoan.cntt@gmail.com

