$(document).ready(function () {

    var boatsLeft = ($('.gameButtonShip').length);
    
    
    


    $('.gameButton').on('click', function () {
        $(this).prop('value','O');
        $(this).prop('disabled', 'true');
        $(this).css('opacity', '0.5');

        var counter = $('#ContentPlaceHolder1_ShotCounter').html();
        counter++;

        $('#ContentPlaceHolder1_ShotCounter').html(counter);

    });

    $('.gameButtonShip').on('click', function () {
        $(this).prop('value', 'X');
        $(this).css('opacity', '0.5');
        $(this).removeClass('.gameButtonShip');

        var counter = $('#ContentPlaceHolder1_ShotCounter').html();
        counter++;

        $('#ContentPlaceHolder1_ShotCounter').html(counter);

        boatsLeft--;
        if (boatsLeft < 1)
            alert("WIN!" + boatsLeft);

        //alert($('.gameButtonShip').length);

        //if ($('.gameButtonShip').length() == 0) {
        //    alert("Win!");
        //}

        var fullHTMLPage = $('#gameBoardWrapper')[0].outerHTML;
        console.log(fullHTMLPage);

        $(this).prop('disabled', 'true');
    });
});
