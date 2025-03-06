// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Site JavaScript Kodları
document.addEventListener('DOMContentLoaded', function() {
    // Skill progress bar animasyonu
    const skillBars = document.querySelectorAll('.skill-progress-bar');
    
    // Skill değerlerini belirleyelim
    const skillValues = [
        { skill: 'html-css', value: 90 },
        { skill: 'bootstrap', value: 85 },
        { skill: 'ui-ux', value: 75 },
        { skill: 'dotnet', value: 80 },
        { skill: 'ef-core', value: 75 }
    ];
    
    // Skill progress bar'ları ayarlayalım
    skillBars.forEach(bar => {
        const skill = bar.getAttribute('data-skill');
        const skillData = skillValues.find(item => item.skill === skill);
        
        if (skillData) {
            setTimeout(() => {
                bar.style.width = skillData.value + '%';
            }, 300);
        }
    });
    
    // Özel iletişim bölümü bağlantı işleyicisi
    const contactLink = document.querySelector('a[href="#contact"]');
    if (contactLink) {
        contactLink.addEventListener('click', function(e) {
            e.preventDefault();
            
            // İletişim bölümünü doğrudan scroll etmek yerine daha basit yaklaşım
            setTimeout(() => {
                window.scrollTo({
                    // Sayfayı neredeyse en alta kaydır
                    top: document.body.scrollHeight - window.innerHeight - 100,
                    behavior: 'smooth'
                });
            }, 100);
        });
    }
    
    // Diğer tüm navbar bağlantıları için normal işleyici
    document.querySelectorAll('a[href^="#"]:not([href="#contact"])').forEach(link => {
        link.addEventListener('click', function(e) {
            e.preventDefault();
            
            const targetId = this.getAttribute('href');
            const targetElement = document.querySelector(targetId);
            
            if (targetElement) {
                const offset = 80;
                const position = targetElement.getBoundingClientRect().top + window.pageYOffset - offset;
                
                window.scrollTo({
                    top: position,
                    behavior: 'smooth'
                });
            }
        });
    });
});

// Portfolio filtresi
$(document).ready(function() {
    $('.portfolio-filter .btn').click(function() {
        $('.portfolio-filter .btn').removeClass('active');
        $(this).addClass('active');
        
        const filter = $(this).data('filter');
        
        if (filter === 'all') {
            $('#portfolio-items > div').fadeIn(300);
        } else {
            $('#portfolio-items > div').hide();
            $('#portfolio-items > div[data-category="' + filter + '"]').fadeIn(300);
        }
    });
    
    // Skill bar animasyonu
    $(window).on('load scroll', function() {
        if ($('.skill-bar').length) {
            $('.skill-bar').each(function() {
                var windowTop = $(window).scrollTop();
                var elementTop = $(this).offset().top;
                var leftToShow = (elementTop - windowTop - $(window).height() + 100);
                
                if (leftToShow < 0) {
                    $(this).css('width', $(this).attr('data-level') + '%');
                }
            });
        }
    });
});
