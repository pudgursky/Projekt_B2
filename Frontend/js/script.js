function addToTable(element) {
  $("#seznam").append("<tr><td>" + element.ime + "</td><td>" + element.starost + "</td></tr>");
}

function checkFields(starost, ime){
  if(starost==""){
    $("#starost-error").addClass("show");
    console.log("STAROST");
  } else {
    $("#starost-error").removeClass("show");
  }

  if(ime == ""){
    $("#ime-error").addClass("show");
    console.log("IME");
  } else {
    $("#ime-error").removeClass("show");
  }

  return ime != "" && starost != "";
}

function localButton() {
  const starost = $("#starost").val();
  const ime = $("#ime").val();

  if(checkFields(starost, ime)){
    var element = {};
    element.starost=starost;
    element.ime = ime;
    addToTable(element);
    $("#starost").val("");
    $("#ime").val("");
  }
}

function serverButton() {
  const starost = $("#starost").val();
  const ime = $("#ime").val();

  if(checkFields(starost, ime)){
    var element = {};
    element.starost=starost;
    element.ime = ime;
    $.ajax({
      type: "POST",
      url: "http://localhost:50514/api/osebe",
      // The key needs to match your method's input parameter (case-sensitive).
      data: JSON.stringify(element),
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function(data){
        console.log(data);
        var data_element = {starost: data.starost, ime: data.ime};
        addToTable(data_element);
      },
      failure: function(errMsg) {
          alert(errMsg);
      }
    });
    $("#starost").val("");
    $("#ime").val("");
  }
}

$(document).ready(function(){
    $("#lokalno").click(function(){
      localButton();
    });

    $("#streznik").click(function() {
      serverButton();
    });


    
    $.get("http://localhost:50514/api/osebe", function(data, status){
        data.seznam.forEach(element => addToTable(element));
      });
});