function addToTable(element) {
  $("#seznam").append("<tr><td>" + element.ime + "</td><td>" + element.starost + "</td></tr>");
}

function localButton() {
  const starost = $("#starost").val();
  const ime = $("#ime").val();
  
  console.log(starost);
  if(starost==""){
    $("#starost-error").show();
    console.log("STAROST");
  } else {
    $("#starost-error").hide();
  }

  if(ime == ""){
    $("#ime-error").show();
    console.log("IME");
  } else {
    $("#ime-error").hide();
  }

  if(ime != "" && starost != ""){
    var element = {};
    element.starost=starost;
    element.ime = ime;
    addToTable(element);
    $("#starost").val("");
    $("#ime").val("");
  }
  console.log("str: " + starost + ", ime: " + ime);
}

$(document).ready(function(){
    $("#lokalno").click(function(){
      localButton();
    });


    
    $.get("http://localhost:50514/api/osebe", function(data, status){
        data.seznam.forEach(element => addToTable(element));
      });
});