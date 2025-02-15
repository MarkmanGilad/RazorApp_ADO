function validate() {
    var res = true;
    res = firstNameVal() && res;

    if (res) {
        return true;
    }
    return false;
}


function firstNameVal() {

    var fName = document.getElementById("NewUser_FirstName").value;
    var msg = document.getElementById("FNameMsg");

    if (fName == "") {
        msg.innerHTML = "You must enter first name !";
        return false
    }
    msg.innerHTML = "";
    return true;

}

