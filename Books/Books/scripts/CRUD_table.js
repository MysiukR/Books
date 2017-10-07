//Change value DropDown(Combobox)
$(document).ready(function () {
    // convert selects already on the page at dom load
    $('select.form-control').combobox();

    $('#it').click(function (e) {
        $('ul.dropdown-menu').toggle();
    });



});

$(document).ready(function () {
    $("#submit").click(function () {
        //Check inputing
       
        var year = document.getElementById('txtYear').value;
        var pages = document.getElementById('txtPages').value;
        var re = new RegExp("193[0-9]|194[0-9]|195[0-9]|196[0-9]|197[0-9]|198[0-9]|199[0-9]|200[0-9]|201[0-7]");
        var re1 = new RegExp("[^0-9]", "g");
        year = year.replace(re, "");
        pages = pages.replace(re1, "a");
        
        if (!year.length && pages.indexOf("a") == -1 && $("#txtName").val() != "" && $("#txtAuthor").val() != "" && $("#txtPages").val() != "" && $("#txtYear").val() != "") {
            var name = $("#txtName").val();
            var author = $("#txtAuthor").val();
            var type_of_book = $("#txtType").val();
            var pages = $("#txtPages").val();
            var year = $("#txtYear").val();
            var markup = "<tr><td>" + name + "</td><td>" + author + "</td><td>" + type_of_book + "</td><td>" + pages + "</td><td>" + year + "</td><td> <input class='btn btn-danger' type='submit' data-toggle='modal' data-target='#myModal1' value='Remove' id='submit' name='submit'/></td></tr>";
            $("table tbody").append(markup);

            $.ajax({
                type: "POST",
                url: "/Home/InsertInDatabase",
                data: "{name:'" + name + "',author:'" + author + "',type_of_book:'" + type_of_book + "',pages:'" + pages + "',year:'" + year + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    //     alert("Hello: " + response.NameBook + " .\nCurrent Date and Time: " + response.DateTime);
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
        } else {  
                $(".alert").removeClass("in").show();
                $(".alert").delay(200).addClass("in").fadeOut(3000);
        }
    });
});

//function Remove(submit){
$(document).ready(function(){
    $("#del_yes").click(function () {  
//Determine the reference of the Row using the Button.
    var row = $(submit).closest("TR");
   var numCell = 0;
   var row = $("table tr").eq(row[0].rowIndex);
   var cell1 = $("td", row).eq(numCell);
   numCell = 1;
   var cell2 = $("td", row).eq(numCell);
   numCell = 3;
   var cell3 = $("td", row).eq(numCell);
        //Get the reference of the Tables.
        var table = $("#TableA")[0];
        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
       $.ajax({
        type: "POST",
        url: "/Home/AjaxMethod",
        data: "{name:'" + cell1.text() + "',author:'" + cell2.text() + "',pages:'" + cell3.text() + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            //"<div class='alert alert-danger'><strong>Danger!</strong> Indicates a dangerous or potentially negative action.</div>"
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    });
});