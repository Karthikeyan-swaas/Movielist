$(document).ready(function () {
    loadData();
});

function loadData() {
    $.ajax({
        url: "/Movies/MovieList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.MoviesName + '</td>';
                html += '<td>' + item.Hero + '</td>';
                html += '<td>' + item.Heroin + '</td>';
                
                html += '<td><a href="#" onclick="return getbyID(' + item.id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Add() {
   // var mov == validate();
   // if (mov == false) {
    //    return false;
    

    var movObj = {
        id: $('#id').val(),
        MoviesName: $('#MoviesName').val(),
        Hero: $('#Hero').val(),
        Heroin: $('Heroin').val()
    };

    $.ajax({
        url: "/Movies/AddMovie",
        data: JSON.stringify(movObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
       
        error: function (erormessage) {
            alert(errormessage.responseText);
        }
        
    });
}

function getbyID(id) {
    $('#MoviesName').css('border-color', 'lightgrey');
    $('#Hero').css('border-color', 'lightgrey');
    $('#Heroin').css('border-color', 'lightgrey');
   
    $.ajax({
        url: "/Movies/getbyMovieID/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#id').val(result.id);
            $('#MoviesName').val(result.MoviesName);
            $('#Hero').val(result.Hero);
            $('#Heroin').val(result.Heroin);
          

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Update() {
    //var res = validate();
   // if (res == false) {
    //   return false;}
    
    var movObj = {
        id: $('#id').val(),
        MoviesName: $('#MoviesName').val(),
        Hero: $('#Hero').val(),
        Heroin: $('#Heroin').val(),
       
    };
    $.ajax({
        url: "/Movies/Update",
        data: JSON.stringify(movObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#id').val("");
            $('#MoviesName').val("");
            $('#Hero').val("");
            $('#Heroin').val("");
          
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function Delele(id) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Movies/Delete/" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function clearTextBox() {
    $('#id').val("");
    $('#MoviesName').val("");
    $('#Hero').val("");
    $('#Heroin').val("");
    
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#MoviesName').css('border-color', 'lightgrey');
    $('#Hero').css('border-color', 'lightgrey');
    $('#Heroin').css('border-color', 'lightgrey');
   
}

function validate() {
    var isValid = true;
    if ($('#MoviesName').val().trim() == "") {
        $('#MoviesName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MoviesName').css('border-color', 'lightgrey');
    }
    return isvalid;
}
