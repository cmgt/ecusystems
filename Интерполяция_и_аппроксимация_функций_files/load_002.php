importMW=function(name){importScript('MediaWiki:'+name+'.js')}
importScript_=importScript
importScript=function(page,proj){if(!proj)importScript_(page)
else{if(proj.indexOf('.')==-1)proj+='.wikipedia.org'
importScriptURI('//'+proj+'/w/index.php?action=raw&ctype=text/javascript&title='+encodeURIComponent(page.replace(/ /g,'_')))}}
var NavigationBarShowDefault=2
var NavigationBarHide='[скрыть]'
var NavigationBarShow='[показать]'
var hasClass=(function(){var reCache={}
return function(element,className){return(reCache[className]?reCache[className]:(reCache[className]=new RegExp("(?:\\s|^)"+className+"(?:\\s|$)"))).test(element.className)}})()
function collapsibleDivs(){var navIdx=0,colNavs=[],i,NavFrame
var divs=document.getElementById('content').getElementsByTagName('div')
for(i=0;NavFrame=divs[i];i++){if(!hasClass(NavFrame,'NavFrame'))continue
NavFrame.id='NavFrame'+navIdx
var a=document.createElement('a')
a.className='NavToggle'
a.id='NavToggle'+navIdx
a.href='javascript:collapseDiv('+navIdx+');'
a.appendChild(document.createTextNode(NavigationBarHide))
for(var j=0;j<NavFrame.childNodes.length;j++)if(hasClass(NavFrame.childNodes[j],'NavHead'))NavFrame.childNodes[j].appendChild(a)
colNavs[navIdx++]=NavFrame}for(i=0;i<navIdx;i++)if((navIdx>NavigationBarShowDefault&&!hasClass(colNavs[i],'expanded'))||hasClass(colNavs[i],'collapsed'))collapseDiv(i)}function collapseDiv(idx){var div=document.getElementById('NavFrame'+idx)
var btn=document.getElementById('NavToggle'+idx)
if(!div||!btn)return false
var isShown=(btn.firstChild.data==NavigationBarHide)
btn.firstChild.data=isShown?NavigationBarShow:NavigationBarHide
var disp=isShown?'none':'block'
for(var child=div.firstChild;child!=null;child=child.nextSibling)if(hasClass(child,'NavPic')||hasClass(child,'NavContent'))child.style.display=disp}if(wgCanonicalNamespace!='Special'){if(wgAction!='history')addOnloadHook(collapsibleDivs)
if(wgAction=='edit'||wgAction=='submit')importScript('MediaWiki:Editpage.js')
if(wgArticleId==3)addOnloadHook(mainPageTab)};mw.loader.state({"site":"ready"});

/* cache key: ruwikibooks:resourceloader:filter:minify-js:7:1788dba3ceae6098827012a945dffc35 */