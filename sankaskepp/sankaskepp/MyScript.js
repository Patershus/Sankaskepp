$(document).ready(function () {

    var boatsLeft = $('.gameButtonShip').length;
    var hits = 0;
    
    
    $('.gameButton').on('click', function () {
        $(this).prop('value','O');
        $(this).prop('disabled', 'true');
        $(this).css('opacity', '0.5');

        var counter = $('#ContentPlaceHolder1_ShotCounter').html();
        counter++;

        $('#ContentPlaceHolder1_ShotCounter').html(counter);
        UpdateScore();

    });

    $('.gameButtonShip').on('click', function () {
        $(this).prop('value', 'X');
        $(this).css('opacity', '0.5');
        $(this).addClass('hitShip');

        
        hits++;

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
        
        UpdateScore();
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

    function UpdateScore() 
    {
        var size = $('#gameBoardWrapper').find('tr').length - 2;
        var counter = $('#ContentPlaceHolder1_ShotCounter').html();
        var score = ((size * size) + (hits * 10000)) / counter;
        score = Math.round(score);
        $('#ContentPlaceHolder1_ScoreCounterLabel').html(score);

    }
});


//function addSunkShipClass() {

//    $('.gameButtonShip').addClass('hitShip');


//}



