var W3CDOM = (document.getElementsByTagName && document.createElement);
var currentTab = 0; // Current tab is set to be the first tab (0)

showTab(currentTab); // Display the current tab
function showTab(n) {
    // This function will display the specified tab of the form...
    var x = document.getElementsByClassName("step");
    x[n].style.display = "block";       

    //... and fix the Previous/Next buttons:
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";

    } else {
        document.getElementById("prevBtn").style.display = "inline-block";
    }
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").innerHTML = "Submit";
    } else {
        document.getElementById("nextBtn").innerHTML = "Next";
    }
    //... and run a function that will display the correct step indicator:
    fixStepIndicator(n)
}

function nextPrev(n) {
   
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("step");
    // Exit the function if any field in the current tab is invalid:
    if (n == 1 && !validateForm()) {
      //  ValidationError();       
        return false;
    }
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;

    // if you have reached the end of the form...
    if (currentTab >= x.length) {
        // ... the form gets submitted:
        ConfirmSubmit();
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);
    window.scrollTo(0, 0);
}

function validateForm() {
    // This function deals with validation of the form fields
    var x, y, i, valid = true;
    firstError = null;
    errorstring = '';

    x = document.getElementsByClassName("step");
    //y = x[currentTab].getElementsByTagName("input");
    y = x[currentTab].querySelectorAll('input, select');

    // A loop that checks every input field in the current tab:
    for (i = 0; i < y.length; i++) {

        if (IsDropDownElement(y[i]) && y[i].required) {
            const selectedOption = y[i].options[y[i].selectedIndex];
            if (selectedOption.index == 0) {
                // add an "invalid" class to the field:
                setInvalidClass(y[i]);
                // and set the current valid status to false
                valid = false;
            }
        } else if (y[i].value.trim() == "" && y[i].required) {
            // add an "invalid" class to the field:
            setInvalidClass(y[i]);
            // and set the current valid status to false
            valid = false;
        }
    }
    
    if (firstError)
        firstError.focus();

    // If the valid status is true, mark the step as finished and valid:
    if (valid) {
        document.getElementsByClassName("stepIndicator")[currentTab].className += " finish";
    }
    return valid; // return the valid status
}


function fixStepIndicator(n) {
    // This function removes the "active" class of all steps...
    var i, x = document.getElementsByClassName("stepIndicator");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    
    if (x[n].classList.contains('finish')) {
        x[n].className = x[n].className.replace(" finish", "");
    }
    //... and adds the "active" class on the current step:
    x[n].className += " active";
}
function IsDropDownElement(element) {
    return element.tagName.toLowerCase() === 'select';
}
function setInvalidClass(element) {
    element.className += " invalid";
    writeError(element, 'This field is required');
}

function writeError(obj, message) {
    validForm = false;
    if (obj.hasError) return;
    if (W3CDOM) {
        obj.className += ' error';
        obj.oninput = removeError;
        var sp = document.createElement('span');
        sp.className = 'error';
        sp.appendChild(document.createTextNode(message));
        obj.parentNode.appendChild(sp);
        obj.hasError = sp;
    }
    else {
        errorstring += obj.name + ': ' + message + '\n';
        obj.hasError = true;
    }
    if (!firstError)
        firstError = obj;
}

function removeError() {
    this.className = this.className.substring(0, this.className.lastIndexOf(' '));
    this.className = this.className.replace(" invalid", "");
    this.parentNode.removeChild(this.hasError);
    this.hasError = null;
    this.oninput = null;
}


function SaveChanges() {
    Swal.fire({
        title: 'Save Changes?',
        text: "You will be able to update your profile later!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, Save changes!'
    }).then((result) => {
        if (result.isConfirmed) {
            if (validateForm()) { 
                currentPageEle.value = currentTab; // set current step
                document.getElementById("msfForm").submit();
            }
        }
    })
}

function ConfirmSubmit () {

    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to update this later!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Submit it!',
        cancelButtonText: 'No!'
    }).then((result) => {
        if (result.isConfirmed) {
            $("#IsSubmitted").val("true");

            // submit form  
            document.getElementById("msfForm").submit();
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            showTab(currentTab - 1);
        }      
    })
}
function resetError(element) {

    if (element.hasError || element.classList.contains('invalid') || element.classList.contains('error')) {
        element.classList.remove("invalid");
        element.classList.remove("error");
        element.parentNode.removeChild(element.hasError);
        element.hasError = null;
    }
}
  
