$(document).ready(function () {

    $('.gameButton').on('click', function () {
        $(this).prop('value','O');
        $(this).prop('disabled', 'true');
        $(this).css('opacity', '0.5');

        var counter = $('#ContentPlaceHolder1_ShotCounter').html();
        counter++;

        $('#ContentPlaceHolder1_ShotCounter').html(counter);

    });
});