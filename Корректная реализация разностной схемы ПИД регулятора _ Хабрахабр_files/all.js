$(document).ready(function(){
  

  
  /**
   * Fast Navigator
   */
  $('#fast_navagator select[name="category"]').change(function(){
    var alias = $(this).val();
    $.post('/json/blogs/category/'+alias+'/', function(json){
      if(json.messages=='ok'){
        var blogs = '';
        for(k in json.blogs){
          blogs += '<option value="'+json.blogs[k].alias+'">'+json.blogs[k].name+'</option>';
        }
        $('#fast_navagator select[name="blog"]').html(blogs).attr('disabled', false);
        $('#fast_navagator button').attr('disabled', false);
      }else{
        show_system_error(json);
      }
    },'json');
  });
  
  $('#fast_navagator').submit(function(){
    var blog = $('#fast_navagator select[name="blog"]').val();
    document.location.href = '/hub/'+blog+'/';
    return false;
  });
  
  /** 
   * Нравится/не нравится хаб
   */
  $('#addHubMember').click(function(){
  	var link = $(this);
  			link.addClass('loading');
    var id = $(this).attr('data-id');
    $.post('/json/hubs/subscribe/', {'hub_id':id}, function(json){
      if(json.messages =='ok'){
        $('#removeHubMember').removeClass('hidden');
        $('#addHubMember').addClass('hidden'); 
        $('#members_count').text(json.members_count_str);       
      }else{
        show_system_error(json);
      }
      link.removeClass('loading');
    },'json');
    return false;
  });
  $('#removeHubMember').click(function(){
    var id = $(this).attr('data-id');
    var link = $(this);
  			link.addClass('loading');
  
      $.post('/json/hubs/unsubscribe/', {'hub_id':id}, function(json){
        if(json.messages =='ok'){
          $('#removeHubMember').addClass('hidden');
          $('#addHubMember').removeClass('hidden');        
          $('#members_count').text(json.members_count_str);
        }else{
          show_system_error(json);
        }
      	link.removeClass('loading');
      },'json');

    return false;
  });
  
  
  
  
  /** 
   * Нравится/не нравится компания
   */
  $('#addCompanyFan').click(function(){
    var id = $(this).attr('data-id');
    var link = $(this);
  			link.addClass('loading');
    $.post('/json/corporation/fan_add/', {'company_id':id}, function(json){
      if(json.messages =='ok'){
        $('#removeCompanyFan').removeClass('hidden');
        $('#addCompanyFan').addClass('hidden'); 
        $('#fans_count').text(json.fans_count_str);       
      }else{
        show_system_error(json);
      }
      link.removeClass('loading');
    },'json');
    return false;
  });
  $('#removeCompanyFan').click(function(){
    var id = $(this).attr('data-id');
		var link = $(this);
  			link.addClass('loading');
      $.post('/json/corporation/fan_del/', {'company_id':id}, function(json){
        if(json.messages =='ok'){
          $('#removeCompanyFan').addClass('hidden');
          $('#addCompanyFan').removeClass('hidden');        
          $('#fans_count').text(json.fans_count_str);
        }else{
          show_system_error(json);
        }
        link.removeClass('loading');

      },'json');

    return false;
  });
  
  
  
  /**
   * Ниже расположен код для блока "Настройки ленты".
   * Кратко: при клике на ссылку "показать настройки" мы подгружаем список категорий аяксом.
   * При клике на категорию подгружаем список блогов аяксом.
   * В конце сабмитится форма с настройками :)
   */
  
  // Preload ajax loader
  var ajaxloader = $('<img src="/i/form/ajax_loader.gif" alt="" class="ajax_loader" align="top"/>');
  

  // global objects      
  var blogs_category = $('#blogs_category');
  var habralenta_settings = $('#habralenta-settings');
  var form_habralenta_settings = $('#form_habralenta_settings');
  var show_habralenta_settings = $('#show_habralenta_settings');
  var save_success = $('#save_success');
  
  /* lenta_blogs.tpl - Hide Settings - hide all categories */
  $('#hide_habralenta_settings').live('click', function(e){
    form_habralenta_settings.toggleClass('show');
    show_habralenta_settings.toggleClass('hide');    
    $.scrollTo(habralenta_settings, 800);
    return false;
  });
  
  /* lenta_blogs.tpl - Show Settings - show all categories */
  $('#show_habralenta_settings').live('click', function(e){
    save_success.removeClass('show');
    if( blogs_category.html() != '' ){
      form_habralenta_settings.toggleClass('show');
      show_habralenta_settings.toggleClass('hide');
      return false
    }else{
      show_habralenta_settings.after(ajaxloader)      
    }
    $.get('/json/hubs/categories/', function(json){
      
          var categorylist = '';
          $.each(json.categories, function(index, category) { 
                        
            var full = category.subscription == 2 ? 'full' : '';
            var part = category.subscription == 1 ? 'part' : '';
            var checkbox_title = category.subscription == 2 ? 'Отписаться от всех хабов в этой категории' : 'Подписаться на все хабы в этой категории';
            var url = (category.alias == 'corporative_blogs') ? '/companies/' : '/hubs/'+category.alias+'/';
            var disabled = (json.lenta_show_all || category.count == 0) ? 'disabled' : '';
            var have_new = category.have_new  ? ' <span class="new">'+category.have_new+'</span>' : '' ;
            var category_title = category.count > 0 ? '<a href="'+url+'" title="Нажмите, чтобы посмотреть хабы из этой категории">'+category.title+'</a>' : '<span class="category_title">'+category.title+'</span>' ;         
            
            categorylist += '<div class="category '+full+' '+part+' '+disabled+'" data-alias="'+category.alias+'">\
                               <div class="checkbox" title="'+checkbox_title+'"></div>\
                               <input type="hidden" name="categories['+category.alias+']" class="input" value="'+category.subscription+'" />\
                               <div class="title">\
                                 '+category_title+'\
                                 <span class="count" title="Количество хабов в категории">('+category.count+')</span>\
                                 '+have_new+'\
                               </div>\
                               <div class="blogs"></div>\
                             </div>';
                             
          });
          /*
          var category_all_selected = json.lenta_show_all ? 'selected' : '';
          categorylist = '<div class="category_all '+category_all_selected+'">\
          									 <div class="checkbox" title="Читать все блоги"></div>\
	                           <input type="hidden" name="lenta_show_all" class="input" value="'+json.lenta_show_all+'" />\
	                           <span class="title">\
	                             Читать все\
	                           </span>\
	                           <span class="lenta-tip" title="Выбрав эту настройку, вы сможете читать все блоги на сайте, включая корпоративные.">*</span>\
          								</div>' + categorylist;
          */
          ajaxloader.remove();
          blogs_category.html(categorylist);
          form_habralenta_settings.toggleClass('show');
          show_habralenta_settings.toggleClass('hide');
          $(".lenta-tip").tipTip({maxWidth: "300", edgeOffset: 10});
          
          /*
          $('.category_all', blogs_category).live('click', function(){
      
          	var input = $('input', this);
          	if($(this).hasClass('selected')){
          		input.val('0');
          		$(this).removeClass('selected');
          		$('#blogs_category .category').removeClass('disabled');
          	}else{
          		input.val('1');
          		$(this).addClass('selected');
          		$('#blogs_category .category').addClass('disabled');
          	}
          });
          */
          
          /* lenta_blogs.tpl - Blogs Category - show all blogs in category */
          $('.category .title a', blogs_category).live('click', function(){
            
            var node = $(this);
            var category = node.parent().parent('.category');
            var blogs = $('.blogs', category);
            var count = $('.title .count',category);
            var alias = category.attr('data-alias');
            
            if(category.hasClass('disabled')) return false;
 
            if(blogs.html()){
              blogs.toggleClass('show');
            }else{
              count.after(ajaxloader);
              
              $.get('/json/hubs/category/'+alias+'/', function(json){
                
                  var bloglist = '';
                  if( alias == 'corporative_blogs' ){
                    //bloglist += '<div class="description">Компании, которые мне нравятся &darr;</div>';
                  }
                  
                  
                  $.each(json.blogs, function(index, blog) { 
                  
                    if( category.hasClass('full') ){
                      blog.subscription = 1;                     
                    }else if( category.hasClass('part') ){
                      // если частично стоит - значит берем то что пришло с сервера.
                    }else{
                      blog.subscription = 0;
                    }
                    var subscription = blog.subscription ? 'subscription' : '';                    
                    var checkbox_title = blog.subscription ? 'Отписаться от хаба' : 'Подписаться на хаб';
                    var url = (alias == 'corporative_blogs') ? '/company/'+blog.alias+'/blog/' : '/hub/'+blog.alias+'/';
                    var is_new = blog.is_new ? ' <span class="new">new</span>' : '' ;
                    bloglist += '<div class="blog '+subscription+'">\
                                   <div class="checkbox" title="'+checkbox_title+'"></div>\
                                   <input type="hidden" name="blogs['+blog.id+']" class="input" value="'+blog.subscription+'" />\
                                   <a href="'+url+'" target="_blank">'+blog.name+'</a>\
                                   '+is_new+'\
                                 </div>';
                  });

                  ajaxloader.remove();
                  blogs.html(bloglist);
                  blogs.toggleClass('show');
                  
                  
                  
                  
                  $('.blog a', blogs).click(function(){
                  		var node = $(this);
                      var blog = node.parent('.blog');
                      var category = blog.parent().parent('.category');
                      
                      if(category.hasClass('disabled')) return false;
                  	
                  });
                  
                  
                  // add click event to blog checkbox
                  
                  $('.blog .checkbox', blogs).click(function(){
                    
                      var node = $(this);
                      var blog = node.parent('.blog');
                      var category = blog.parent().parent('.category');
                      var blog_input = $('.input',blog);
                      var category_input = $('> .input',category);     

                      if(category.hasClass('disabled')) return false;
                                            
                      if( blog.hasClass('subscription') ){
                        blog.removeClass('subscription');
                        blog_input.val(0);
                      }else{
                        blog.addClass('subscription');
                       blog_input.val(1);
                      }
                      
                      // Здесь нужно проверить - сколько галочек в списке поставлено.
                      // Если все - то надо ставить для категории класс 'full'
                      // Если не все, но хотя бы одна - то класс 'part'
                      // Если не одной, то надо убирать у категории классы part или full.
                      var active_blogs = $('.subscription',blogs);
                      var all_blogs = $('.blog',blogs);
                                    
                      if( active_blogs.size() == 0 ){
                        category.removeClass('part').removeClass('full');
                        category_input.val(0);
                      }else if(active_blogs.size() == all_blogs.size()){
                        category.removeClass('part').addClass('full');
                        category_input.val(2);
                      }else{
                        category.removeClass('full').addClass('part');
                        category_input.val(1);
                      }
                                   
                    });
                  
                  
                },'json');
                
            }
            
            
            return false;
          });
          //////
          
          /* lenta_blogs.tpl - Category Checkbox */
          $('.category > .checkbox',blogs_category).live('click', function(){
          	
            var node = $(this);
            var category = node.parent('.category');
            var alias = category.attr('data-alias');
            var blogs = $('.blogs',category);
            var category_input = $('.input',category);
            
            if(category.hasClass('disabled')) return false;
            
            //console.log('event click category '+alias);
            
            if( category.hasClass('full') ){
              category.removeClass('full').removeClass('part');
              category_input.val(0);
              $('.blog',blogs).removeClass('subscription');
              $('.blog .input',blogs).val(0);
            }else if( category.hasClass('part') ){
              category.removeClass('part').addClass('full');
              category_input.val(2);
              $('.blog',blogs).addClass('subscription');
              $('.blog .input',blogs).val(1);
            }else{
              category.addClass('full');
              category_input.val(2);
              $('.blog',blogs).addClass('subscription');
              $('.blog .input',blogs).val(1);
            }
            
            return false;
          });
          
       },'json');
      
      return false;
  });
  
  ///////// SAVE FORM
  
  $('#form_habralenta_settings').ajaxForm({
    url: '/json/hubs/save_subscriptions/',
    dataType: 'json',
    beforeSubmit: function(){
      $('#form_habralenta_settings .btn').addClass('loading');
    },
    success: function(json){
        $('#form_habralenta_settings .btn').removeClass('loading');
        if(json.messages == 'ok'){
          //form_habralenta_settings.toggleClass('show');
          //show_habralenta_settings.toggleClass('hide');
          //save_success.addClass('show');
          //var position = habralenta_settings.getPosition();
          //$(window).scrollTo(0, position.y);    
          document.location.reload();   
        }else{
          show_system_error(json);
        }
        show_system_warnings(json);
    }
  });















});