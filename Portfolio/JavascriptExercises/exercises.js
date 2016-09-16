//const OPERATION_TYPE_LEAST = 'operationTypeLeast';
//const OPERATION_TYPE_GREATEST = 'operationTypeGreatest';
//const OPERATION_TYPE_MEAN = 'operationTypeMean';
//const OPERATION_TYPE_SUM = 'operationTypeSum';
//const OPERATION_TYPE_PRODUCT = 'operationTypeProduct';
////const WHITESPACE = '\u00A0';
//const EMPTY_STRING = '';

//var operationType;

//var e1_val0 = EMPTY_STRING;
//var e1_val1 = EMPTY_STRING;
//var e1_val2 = EMPTY_STRING;
//var e1_val3 = EMPTY_STRING;
//var e1_val4 = EMPTY_STRING;
//var e1_arrValues = [];

//var least;
//var greatest;
//var mean;
//var sum;
//var product;

//function e1_onSubmit() {
//    event.preventDefault();
//    grabEntries();
//    e1_arrValues = [e1_val0, e1_val1, e1_val2, e1_val3, e1_val4];
//    mathSwitch();
//}

//function grabEntries() {
//    e1_val0 = parseInt($('#e1_inp0').val());
//    e1_val1 = parseInt($('#e1_inp1').val());
//    e1_val2 = parseInt($('#e1_inp2').val());
//    e1_val3 = parseInt($('#e1_inp3').val());
//    e1_val4 = parseInt($('#e1_inp4').val());
//}

//function didUserProvideValues() {
//    return (null != e1_val0 && EMPTY_STRING != e1_val0 && 
//            null != e1_val1 && EMPTY_STRING != e1_val1 &&
//            null != e1_val2 && EMPTY_STRING != e1_val2 &&
//            null != e1_val3 && EMPTY_STRING != e1_val3 &&
//            null != e1_val4 && EMPTY_STRING != e1_val4);
//}

//function didUserRunProgram() {
//    var e1_outputMessage = $('#e1_output').text();
//    return EMPTY_STRING != e1_outputMessage;
//}

///* generate a new result for different type of operation
//   only if the user has entered value and a result exists */
//function onSelectChanged() {
//    if (didUserProvideValues() && didUserRunProgram()) {
//        mathSwitch();
//    }
//}

//function sortNumericAscending(a, b) {
//    return a - b;
//}

//function sortNumericDescending(a, b) {
//    return b - a;
//}

//function mathSwitch() {
//    operationType = $('#selectOperation').val();
//    switch(operationType) {
//        case OPERATION_TYPE_LEAST:
//            determineLeast();
//            break;
//        case OPERATION_TYPE_GREATEST:
//            determineGreatest();
//            break;
//        case OPERATION_TYPE_MEAN:
//            determineMean();
//            break;
//        case OPERATION_TYPE_SUM:
//            determineSum();
//            break;
//        case OPERATION_TYPE_PRODUCT:
//            determineProduct();
//            break;
//    }
//}

//function determineLeast() {
//    e1_arrValues.sort(sortNumericAscending);
//    least = e1_arrValues[0];
//    $('#e1_output').text('Least: ' + least);
//}

//function determineGreatest() {
//    e1_arrValues.sort(sortNumericDescending);
//    greatest = e1_arrValues[0];
//    $('#e1_output').text('Greatest: ' + greatest);
//}

//function determineMean() {
//    mean = 0;
//    for (var i=0; i < e1_arrValues.length; i++) {
//        mean += e1_arrValues[i];
//    }
//    mean /= e1_arrValues.length;
//    $('#e1_output').text('Mean: ' + mean);
//}

//function determineSum() {
//    sum = 0;
//    for (var i=0; i < e1_arrValues.length; i++) {
//        sum += e1_arrValues[i];
//    }
//    $('#e1_output').text('Sum: ' + sum);
//}

//function determineProduct() {
//    product = 1;
//    for (var i=0; i < e1_arrValues.length; i++) {
//        product *= e1_arrValues[i];
//    }
//    $('#e1_output').text('Product: ' + product);
//}

//function e1_onReset() {
//    $('#e1_inp0').val(EMPTY_STRING);
//    $('#e1_inp1').val(EMPTY_STRING);
//    $('#e1_inp2').val(EMPTY_STRING);
//    $('#e1_inp3').val(EMPTY_STRING);
//    $('#e1_inp4').val(EMPTY_STRING);
//    $('#e1_output').text(EMPTY_STRING);
//}

/********** BEGIN exercise-02 code **********/
//function e2_onSubmit() {
//    event.preventDefault();
//    var e2_val0 = parseInt($('#e2_inp0').val());
//    var factorial = e2_val0;
//    for (i = 1; i < e2_val0; i++) {
//        factorial *= i;
//    }
//    var e2_msg = e2_val0 + ' factorial is ' + factorial;
//    $('#e2_inp0').val('');
//    $('#e2_output').text(e2_msg);
//}
/********** END exercise-02 code **********/

/********** BEGIN exercise-03 code **********/
//function e3_onSubmit() {
//    event.preventDefault();
//    var e3_val0 = promptForValue();
//    var e3_val1 = promptForValue(false, true);
//    e3_main(e3_val0, e3_val1);
//}

//function e3_main(val0, val1) {
//    while (1 >= val0 || 100 <= val0 || isNaN(val0)) {
//        val0 = promptForValue(true);
//    }

//    while (1 >= val1 || 100 <= val1 || isNaN(val1)) {
//        val1 = promptForValue(true, true);
//    }

//    var e3_strVal;
//    var modFizz;
//    var modBuzz;
//    var strFizz = "Fizz";
//    var strBuzz = "Buzz";

//    for (i=1; i < 100; i++) {
//        e3_strVal = "";
//        modFizz = (0 == i % val0 ? true : false);
//        modBuzz = (0 == i % val1 ? true : false);

//        if (!modFizz && !modBuzz) {
//            e3_strVal += i;
//        }
//        else {
//            if (modFizz) {
//                e3_strVal += strFizz;
//            }
//            if (modBuzz) {
//                e3_strVal += strBuzz;
//            }
//        }
//        $('#e3_output').append($("<li>").text(i + '.)' + spaceMaker(i) + e3_strVal));
//        $('#e3_output').append($("<li>").text(WHITESPACE));
//    }
//}

//function spaceMaker(i) {
//    if (99 < i) {
//        return WHITESPACE;
//    } else if (9 < i) {
//        return WHITESPACE+WHITESPACE+WHITESPACE;
//    } else {
//        return WHITESPACE+WHITESPACE+WHITESPACE+WHITESPACE+WHITESPACE;
//    }
//}

//function promptForValue(doScoldUser=false, promptForSecondValue=false) {
//    var strInstructions = promptForSecondValue ? "Enter a second numeric value between 1 & 100." : "Enter a numeric value between 1 & 100.";
//    var strScold = "YOU FAILED TO FOLLOW INSTRUCTIONS. PLEASE TRY AGAIN."
//    var strMessage = doScoldUser ? strScold + " " + strInstructions : strInstructions;
//    return parseInt(prompt(strMessage));
//}

//function e3_onReset() {
//    event.preventDefault();
//    $('#e3_output').text('');
//}
/********** END exercise-03 code **********/

/********** BEGIN exercise-04 code **********/
//var e4_arrStr = [];
//var e4_arrStrReverse = [];
//var e4_val0 = "";
//var e4_reverse = "";

//function e4_onSubmit() {
//    event.preventDefault();
//    e4_val0 = $('#e4_inp0').val();
//    for (var i = 0; i < e4_val0.length; i++) {
//        e4_arrStr.push(e4_val0.charAt(i));
//    }
//    e4_arrStrReverse = e4_arrStr.reverse();
    
//    for (var i = 0; i < e4_arrStrReverse.length; i++)
//    {
//        e4_reverse += e4_arrStrReverse[i];        
//    }
    
//    (e4_val0.toUpperCase() === e4_reverse.toUpperCase()) ? $('#e4_output').text('The word "' + e4_val0 + '" is a palindrome.') : $('#e4_output').text('The word "' + e4_val0 + '" is not a palindrome.');
//    e4_onReset();
//}

//function e4_onReset() {
//    $('#e4_inp0').val('');
//    e4_arrStr = [];
//    e4_arrStrReverse = [];
//    e4_val0 = "";
//    e4_reverse = "";
//}
/********** END exercise-04 code **********/