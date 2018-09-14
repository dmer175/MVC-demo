/// <reference path="jquery-1.8.2.js" />
/// <reference path="jquery-1.8.2.min.js" />
function upload() {
    var formData = new FormData($('#form1')[0]);
    alert(formData);
    $.ajax({
        url: '../../Handler/uploadHandler.ashx',
        data: formData,
        type: 'post',
        cache: false,
        contentType: false,
        processData: false,
        error: function (data) {
            alert(data);
            alert('失败！');
        },
        success: function (data) {
            alert(data);
            alert('成功！');
            document.getElementById("imgDemo").src = data;
        }

    });
}
function JsTest() {
    var content = document.getElementById("account").value;
    $.ajax({
        //url: '../../Handler/AjaxDemoHandler.ashx',
        url: 'Users/Index',
        data: { demoData: content },
        type: 'post',
        error: function (data) {
            alert(data);
            if (data == "false") {
                alert('Ajax执行失败！');
            }
            else {
                alert('Ajax执行成功！');
            }
        },
        success: function (data) {
            alert(data);
            if (data == "true") {
                alert('Ajax执行成功！');
            } else {
                alert('Ajax执行失败！');
            }

        }
    });

}