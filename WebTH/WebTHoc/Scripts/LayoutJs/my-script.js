// var a = true;
// $(document).ready(function(){
//     $("#flip").click(function(){
//         if(a){  
//             console.log("thu");
//             $("#list-menu-right").slideDown("slow");
//             $("#flip").css({
//                 "margin-left": "160px",
//                 // "position": "fixed"
//             });
//             a = false;
//         }else{
//             $("#list-menu-right").slideUp("slow");
//             $("#flip").css({
//                 // "margin-left": "150px",
//                 // "position": "fixed"
//             });
//             a = true;
//         }
//     });
// });

if ($('#back-to-top').length) {
    var scrollTrigger = 100, // px
        backToTop = function () {
            var scrollTop = $(window).scrollTop();
            if (scrollTop > scrollTrigger) {
                $('#back-to-top').addClass('show');
            } else {
                $('#back-to-top').removeClass('show');
            }
        };
    backToTop();
    $(window).on('scroll', function () {
        backToTop();
    });
    $('#back-to-top').on('click', function (e) {
        e.preventDefault();
        $('html,body').animate({
            scrollTop: 0
        }, 700);
    });
}

