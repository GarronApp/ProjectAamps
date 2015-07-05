function Development()
{
    var instance = this;


    this.registerEvents()
    {
        $('.thumbnail').hover(
        function () {

            $(this).find('.caption').fadeIn(150); //.fadeIn(250)
        },
        function () {
            $(this).find('.caption').fadeOut(150); //.fadeOut(205)
        }
        )
    }
}