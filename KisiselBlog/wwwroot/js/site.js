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
    
    // Portfolio kartları için animasyon
    const portfolioItems = document.querySelectorAll('.portfolio-item');
    
    if (portfolioItems.length > 0) {
        portfolioItems.forEach((item, index) => {
            // Görünüm animasyonu ekle
            item.style.opacity = '0';
            item.style.transform = 'translateY(20px)';
            
            setTimeout(() => {
                item.style.transition = 'all 0.5s ease';
                item.style.opacity = '1';
                item.style.transform = 'translateY(0)';
            }, 100 * index); // Her kart için kademeli animasyon
        });
    }
    
    // Proje detay sayfasında animasyon
    const projectDetail = document.querySelector('.project-detail-page');
    if (projectDetail) {
        const elements = projectDetail.querySelectorAll('.animate-fadeInUp');
        
        elements.forEach(element => {
            // Görünüm animasyonu ekle
            element.style.opacity = '0';
            
            // Sayfa yüklendiğinde animasyonu başlat
            setTimeout(() => {
                element.style.opacity = '1';
            }, 100);
        });
    }
    
    // Modal açıldığında animasyon
    const modals = document.querySelectorAll('.modal');
    if (modals.length > 0) {
        modals.forEach(modal => {
            modal.addEventListener('shown.bs.modal', function() {
                const elements = modal.querySelectorAll('.animate-fadeInUp');
                
                elements.forEach((element, index) => {
                    element.style.opacity = '0';
                    element.style.transform = 'translateY(20px)';
                    
                    setTimeout(() => {
                        element.style.transition = 'all 0.5s ease';
                        element.style.opacity = '1';
                        element.style.transform = 'translateY(0)';
                    }, 100 * index);
                });
            });
        });
    }
    
    // Tüm portfolyo kartlarının görüntülerinin yüklenip yüklenmediğini kontrol edelim
    const portfolioImages = document.querySelectorAll('.portfolio-item img');
    
    portfolioImages.forEach(img => {
        // Eğer görüntü zaten önbellekte varsa veya yüklenmişse
        if (img.complete) {
            console.log('Image already loaded:', img.src);
        } else {
            img.addEventListener('load', function() {
                console.log('Image loaded successfully:', img.src);
            });
            
            img.addEventListener('error', function() {
                console.error('Error loading image:', img.src);
                // Hata durumunda bir placeholder görüntü gösterelim
                img.src = '/images/placeholder.jpg';
            });
        }
    });
});

// Portfolio filtresi
$(document).ready(function() {
    $('.portfolio-filter .btn').click(function() {
        $('.portfolio-filter .btn').removeClass('active');
        $(this).addClass('active');

        var filter = $(this).data('filter');
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
