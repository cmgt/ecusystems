/*
	habraWYG - простой визивиг
*/

habraWYG = {

	insertTagWithText: function (link, tagName){
		var startTag = '<' + tagName + '>';
		var endTag = '</' + tagName + '>';
		habraWYG.insertTag(link, startTag, endTag);
		return false;
	},

	insertImage: function(link){
		var src = prompt('Введите src картинки', 'http://');
		if(src){
			habraWYG.insertTag(link, '<img src="' + src + '" alt="image"/>', '');
		}
		return false;
	},

	insertLink: function(link){
		var href = prompt('Введите URL ссылки', 'http://');
		if(href){
			habraWYG.insertTag(link, '<a href="' + href + '">', '</a>');
		}
		return false;
	},

	insertUser: function(link){
		var login = prompt('Введите никнейм пользователя', '');
		if(login){
			habraWYG.insertTag(link, '<hh user="' + login + '"/>', '');
		}
		return false;
	},

	insertHabracut: function(link){
		habraWYG.insertTag(link, '<habracut />', '');
		return false;
	},

	insertTag: function(link, startTag, endTag, repObj){
			var textareaParent = $(link).parents('.editor');

			var textarea = $('textarea',textareaParent).get(0);
			textarea.focus();

			var scrtop = textarea.scrollTop;

			var cursorPos = habraWYG.getCursor(textarea);
			var txt_pre = textarea.value.substring(0, cursorPos.start);
			var txt_sel = textarea.value.substring(cursorPos.start, cursorPos.end);
			var txt_aft = textarea.value.substring(cursorPos.end);

			if(repObj){
				txt_sel = txt_sel.replace(/\r/g, '');
				txt_sel = txt_sel != '' ? txt_sel : ' ';
				txt_sel = txt_sel.replace(new RegExp(repObj.findStr, 'gm'), repObj.repStr);
			}

			if (cursorPos.start == cursorPos.end){
				var nuCursorPos = cursorPos.start + startTag.length;
			}else{
				var nuCursorPos=String(txt_pre + startTag + txt_sel + endTag).length;
			}

			textarea.value = txt_pre + startTag + txt_sel + endTag + txt_aft;


			/*
			if(textarea.setSelectionRange) {
				textarea.setSelectionRange(nuCursorPos - 5, nuCursorPos);
			}
			*/
			habraWYG.setCursor(textarea, nuCursorPos, nuCursorPos);

			if (scrtop) textarea.scrollTop = scrtop;

			return false;
	},

	insertTagFromDropBox: function(link){
			habraWYG.insertTagWithText(link, link.value);
			link.selectedIndex = 0;
	},

	insertList: function(link){

			var startTag = '<' + link.value + '>\n';
			var endTag = '\n</' + link.value + '>';

			var repObj = {
				findStr: '^(.+)',
				repStr: '\t<li>$1</li>'
			}

			habraWYG.insertTag(link, startTag, endTag, repObj);

			link.selectedIndex = 0;
	},
	
	insertSource: function(select){

			var startTag = '<source lang="' + select.value + '">\n';
			var endTag = '\n</source>';

			habraWYG.insertTag(select, startTag, endTag);

			select.selectedIndex = 0;
	},


	insertTab: function(e, textarea){
			if(!e) e = window.event;
			if (e.keyCode) var keyCode = e.keyCode;
			else if (e.which) var keyCode = e.which;

			//alert(keyCode);
			switch(e.type){
				case 'keydown':
					if(keyCode == 16){
						habraWYG.shift = true;
						//alert('1');
					}
					break;

				case 'keyup':
					if(keyCode == 16) {
						habraWYG.shift = false;
						//alert('2');
					}

					break;
			}

			textarea.focus();
			var cursorPos = habraWYG.getCursor(textarea);

			if (cursorPos.start == cursorPos.end){
				return true;


			} else if(keyCode == 9 && !habraWYG.shift){
				var repObj = {
					findStr: '^(.+)',
					repStr: '\t$1'
				}
				habraWYG.insertTag(textarea, '', '', repObj);
				return false;

			} else if(keyCode == 9 && habraWYG.shift){
				var repObj = {
					findStr: '^\t(.+)',
					repStr: '$1'
				}
				habraWYG.insertTag(textarea, '', '', repObj);
				return false;
			}
	},

	getCursor: function(input){
			var result = {start: 0, end: 0};
			if (input.setSelectionRange){
				result.start= input.selectionStart;
				result.end = input.selectionEnd;
			} else if (!document.selection) {
				return false;
			} else if (document.selection && document.selection.createRange) {
				var range = document.selection.createRange();
				var stored_range = range.duplicate();
				stored_range.moveToElementText(input);
				stored_range.setEndPoint('EndToEnd', range);
				result.start = stored_range.text.length - range.text.length;
				result.end = result.start + range.text.length;
			}
			return result;
	},

	setCursor: function(textarea, start, end){
			if(textarea.createTextRange) {
				var range = textarea.createTextRange();
				range.move("character", start);
				range.select();
			} else if(textarea.selectionStart) {
				textarea.setSelectionRange(start, end);
			}
	}

}

