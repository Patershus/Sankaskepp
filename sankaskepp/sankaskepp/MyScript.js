$(document).ready(function () {

    var boatsLeft = $('.gameButtonShip').length;
    
    
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
        $(this).addClass('hitShip');

        //addSunkShipClass();


        var counter = $('#ContentPlaceHolder1_ShotCounter').html();
        counter++;

        $('#ContentPlaceHolder1_ShotCounter').html(counter);

        
        if (boatsLeft === $('.hitShip').length)
            alert("WIN!");

        //alert($('.gameButtonShip').length);

        //if ($('.gameButtonShip').length() == 0) {
        //    alert("Win!");
        //}

        //var fullHTMLPage = $('#gameBoardWrapper')[0].outerHTML;
        

        $(this).prop('disabled', 'true');
    });

    $('#saveButton').on('click', function () {

        var fullHTMLPage = $('#gameBoardWrapper')[0].outerHTML;

        var encodedPage = escape(fullHTMLPage);
        $.post("game.aspx", { action: 'save', savedString: encodedPage }).done(function () {
            alert('saved'); 
        });
       // window.location.href = "game.aspx?action=save&savedString=" + fullHTMLPage;
    });
});


function addSunkShipClass() {

    $('.gameButtonShip').addClass('hitShip');


}
