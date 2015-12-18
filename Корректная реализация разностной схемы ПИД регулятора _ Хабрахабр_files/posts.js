/**
 * Скрипты для постов
 */


/**
 * Функция для обработки формы опроса в посте-вопросе.
 */
function posts_poll(form, button, action, target_id){
  $(form).ajaxSubmit({
      url: '/json/polling/',
      data: {ti: target_id, action: action},
      dataType: 'json',
      beforeSubmit: function(){
        $(button).addClass('loading');
      },
      success: function(json){
        if(json.messages == 'ok'){
        	$(form).replaceWith(json.html);
        	$(button).removeClass('loading');
        }else{
		      show_system_error(json);
		    }
      }
  });
  
}



/**
 * Функция для голосования за посты.
 */
function posts_vote(link, target_id, target_type, vote){
  $.post('/json/vote/',{ti:target_id, tt:target_type, v:vote},function(json){   
    if(json.messages == 'ok'){
      var voting = $('#infopanel_post_'+target_id+' .voting');
      
      // выделим отмеченный пункт.
      if(vote === 1){
        voting.addClass('voted_plus').attr('title','Вы проголосовали положительно.');
      }else if(vote === -1){
        voting.addClass('voted_minus').attr('title','Вы проголосовали отрицательно.');
      }else{
        voting.addClass('voted');
        $('.plus',voting).replaceWith('<span class="plus" title="После просмотра результатов голосовать нельзя"></span>');
        $('.minus',voting).replaceWith('<span class="minus" title="После просмотра результатов голосовать нельзя"></span>');  
      }
      
      // обновим кол-во голосов
      $('.score', voting).replaceWith('<span class="score" title="Всего '+json.votes_count+': &uarr;'+json.votes_count_plus+' и &darr;'+json.votes_count_minus+'">'+json.score+'</span>');
      
      // раскрасим positive / negative
      $('.mark', voting).attr('class','mark '+json.sign);
    }else{
      show_system_error(json);
    }
  },'json');
  return false;
}

/** 
 * Функция для добавления поста в избранное.
 */
function posts_add_to_favorite(link, target_type, target_id){
  
  var tags = $('#post_'+target_id+' .tags');  
  var favs_count = $('#infopanel_post_'+target_id+' .favs_count');
      var count = favs_count.text() ? parseInt(favs_count.text()) : 0;
          
  if($(link).hasClass('add')){
    var action = 'add';
  }else{
    var action = 'remove';
  }
  
  $.post('/json/favorites/', {tt: target_type, ti: target_id, action: action}, function(json){
      if(json.messages == 'ok'){
        if(action == 'add'){
        	$.jGrowl('Пост добавлен в избранное', { });
        	$(link).removeClass('add').addClass('remove');
			    // теперь нужно показать кнопку "Изменить свои метки".    
			    if($('.favourites_edit_tags',tags).length == 0){
			      tags.append('<li class="favourites_edit_tags"><a href="#" onclick="return show_edit_tags(this, \''+target_type+'\', '+target_id+');">Изменить свои метки</a></li>');
			    }
			    favs_count.text(count + 1);
        }else{
        	$.jGrowl('Пост удален из избранного', { });
			    $(link).addClass('add').removeClass('remove');
			    // удалим ссылку "Изменить свои метки".
			    $('.favourites_edit_tags',tags).remove();
			    $('#edit_tags_form').hide();
			    var new_count = count - 1;
			    
			    favs_count.text(new_count ? new_count : '');   
			    $('#post_'+target_id+' .tags li.fav').remove(); 
        }
      }else{
        show_system_error(json)
      }
  },'json');
  
  
  return false; 
}

/**
 * Функция для показа формы редактирования собственных тегов.
 */
function show_edit_tags(link, target_type, target_id){
  var edit_tags_form = $('#edit_tags_form');
  $('input[name="tt"]',edit_tags_form).val(target_type);
  $('input[name="ti"]',edit_tags_form).val(target_id);
  var tags = [];
  $('#post_'+target_id+' ul.tags li.fav a').each(function(){
    tags[tags.length] = $(this).text();
  });
  
  $('input[name="tags_string"]',edit_tags_form).val( tags.join(', ') );
  $('#post_'+target_id+' .tags').after(edit_tags_form);
  edit_tags_form.show();
  
  return false;
}

/**
 * Функция для закрытия формы редактирования собственных тегов.
 */
function close_edit_tags(){
  $('#edit_tags_form').hide();
  return false;
}

$(document).ready(function(){
  
  
	

  
  
  // инициализируем автокомлпит для формы ввода пользовательских тегов
  $('#edit_tags_form .tags_string').autocomplete({
    serviceUrl: '/json/suggest/', 
    minChars: 2, 
    delimiter: /(,|;)\s*/, // Разделитель для нескольких запросов, символ или регулярное выражение
    maxHeight: 400, 
    width: 300, 
    zIndex: 9999, 
    deferRequestBy: 500, 
    params: { type: 'tags'}
  });
  
  // обработчик формы сохранения тегов.
  if($('#edit_tags_form form').size()){
	  $('#edit_tags_form form').ajaxForm({
	      url: '/json/favorites/',
	      dataType: 'json',
	      beforeSubmit: function(){
	        $('#edit_tags_form .submit').addClass('loading');
	      },
	      success: function(json){
	        var edit_tags_form = $('#edit_tags_form');
	        var target_id = $('input[name="ti"]',edit_tags_form).val();
	        var target_type = $('input[name="tt"]',edit_tags_form).val();
	        $('#post_'+target_id+' .tags li.fav').remove();
	        
	        // вставим добавленные теги в список тегов к посту
	        for(k in json.user_tags){
	          
	          $('#post_'+target_id+' .tags .favourites_edit_tags').before('<li class="fav">, <a rel="tag" href="/tag/'+json.user_tags[k]+'/">'+json.user_tags[k]+'</a></li>');
	        }
	        
	        $('#edit_tags_form .submit').removeClass('loading');
	        $('#edit_tags_form').hide();
	      }
	  });
  }
  $('#lenta_notifications .close').click(function(){
  	$('#lenta_notifications').fadeOut();
  	$.post('/json/notifications/hint_get_more_blogs/', function(json){
  		if(json.messages == 'ok'){

      }else{
        show_system_error(json)
      }
  	},'json');
  	return false;
  		
  })
  
  
});