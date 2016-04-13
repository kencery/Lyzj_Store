if( document.implementation.hasFeature("XPath", "3.0") ){
	XMLDocument.prototype.selectNodes = function(cXPathString, xNode){
		if( !xNode )xNode = this;
		var oNSResolver = this.createNSResolver(this.documentElement);
		var aItems = this.evaluate(cXPathString, xNode, oNSResolver,XPathResult.ORDERED_NODE_SNAPSHOT_TYPE, null);
		var aResult = [];
		for( var i = 0; i < aItems.snapshotLength; i++)
			aResult[i] =  aItems.snapshotItem(i);
		return aResult;
	}
	
	// prototying the Element
	Element.prototype.selectNodes = function(cXPathString){
		if(this.ownerDocument.selectNodes)
			return this.ownerDocument.selectNodes(cXPathString, this);
		else
			throw "For XML Elements Only";
	}
	
	// prototying the XMLDocument
	XMLDocument.prototype.selectSingleNode = function(cXPathString, xNode){
		if( !xNode )xNode = this;
		var xItems = this.selectNodes(cXPathString, xNode);
		if( xItems.length > 0 )
			return xItems[0];
		else
			return null;
	}
	
		// prototying the Element
	Element.prototype.selectSingleNode = function(cXPathString){
		if(this.ownerDocument.selectSingleNode)
			return this.ownerDocument.selectSingleNode(cXPathString, this);
		else
			throw "For XML Elements Only";
	}
	
	HTMLElement.prototype.insertAdjacentElement=function(where,parsedNode){
		switch(where){
			case "beforeBegin":
				this.parentNode.insertBefore(parsedNode,this);
				break;
			case "afterBegin":
				this.insertBefore(parsedNode,this.firstChild);
				break;
			case "beforeEnd":
				this.appendChild(parsedNode);
				break;
			case "afterEnd":
				if(this.nextSibling)
					this.parentNode.insertBefore(parsedNode,this.nextSibling);
			else
				this.parentNode.appendChild(parsedNode);
				break;
		}
	}

	HTMLElement.prototype.insertAdjacentHTML=function(where,htmlStr){
		var r=this.ownerDocument.createRange();
		r.setStartBefore(this);
		var parsedHTML=r.createContextualFragment(htmlStr);
		this.insertAdjacentElement(where,parsedHTML);
	}

}

//code by ctf_wren 2007-9-10 8:58:45
function drawClass(args){
	this.SelectName = args.SelectName?args.SelectName:"Select"+Math.ceil(Math.random()*10000);
	this.DefaultValue = args.DefaultValue?args.DefaultValue:null;			//默认值
	this.LoadDataByParentId = args.LoadDataByParentId?args.LoadDataByParentId:null;
	this.MaxDepth = args.MaxDepth?args.MaxDepth:null;//最多显示多少级
	
	this.ShowSelectsCount = args.ShowSelectsCount?args.ShowSelectsCount:1;				//设置一开始显示多少个select
	this.ShowSelectRows = args.ShowSelectRows?args.ShowSelectRows:1;					//显示Select几行
	this.ShowSelectCssStyle = args.ShowSelectCssStyle?args.ShowSelectCssStyle:null;		//样式
	this.ShowSelectCssClass = args.ShowSelectCssClass?args.ShowSelectCssClass:null;		//样式
	
	this.NullValue = args.NullValue?args.NullValue:[['','请选择']];//是否显示 请选择 这个option，直接传入这个HTML代码，如果没有，则传入[]
	
	this.AttrValueField = args.AttrValueField?args.AttrValueField:"v";
	this.AttrTextField = args.AttrTextField?args.AttrTextField:"n";
	
	this.$=function(_id){return document.getElementById(_id);}

	this.LoadXml=function(src){
		var xmlDoc;
		if(window.ActiveXObject){
			xmlDoc = new ActiveXObject('Microsoft.XMLDOM');
			xmlDoc.async = false;
			xmlDoc.load(src);
			return xmlDoc.documentElement;
		}
		if (document.implementation&&document.implementation.createDocument){
			xmlDoc = document.implementation.createDocument('', '', null);
			xmlDoc.async = false;
			xmlDoc.load(src);
			return xmlDoc.firstChild;
		}
		alert('您的浏览器不支持XML操作，请更新您的浏览器！\n建议使用IE5.5以上的版本。');
		return null;
	}
	//必须把this.LoadXml方法写在前面
	this._Data = (typeof args.Data)=="string"?this.LoadXml(args.Data):args.Data;//数据XML文件
	
	this.LoadNode = function(id){return this._Data.selectSingleNode("//i[@v="+id+"]");}
	
	this.LoadClassRoute=function(){
		if(this.NowNode == null)
			if(this.RootNode==this._Data)
				return [{value:null,text:null}];
			else
				return [{value:this.RootNode.getAttribute(this.AttrValueField),text:this.RootNode.getAttribute(this.AttrTextField)}];
		else{
			var ClassRoute = [{value:this.NowNode.getAttribute(this.AttrValueField),text:this.NowNode.getAttribute(this.AttrTextField)}];
			var node = this.NowNode;
			while(node!=this.RootNode){
				if(node==this._Data)
					if(this.RootNode==this._Data)
						return [{value:null,text:null}];
					else
						return [{value:this.RootNode.getAttribute(this.AttrValueField),text:this.RootNode.getAttribute(this.AttrTextField)}];
				node = node.parentNode;
				ClassRoute.unshift(node==this._Data?{value:null,text:null}:{value:node.getAttribute(this.AttrValueField),text:node.getAttribute(this.AttrTextField)});
			}
		}
		return ClassRoute;
	}
	

	this.GetSelect=function(Node,SelectedValue,depth){
		var tmp = new Array();
		tmp.push('<select size="'+this.ShowSelectRows+'"');
		if(this.ShowSelectCssStyle != null)tmp.push(' style="'+this.ShowSelectCssStyle+'"');
		if(this.ShowSelectCssClass != null)tmp.push(' class="'+this.ShowSelectCssClass+'"');
		tmp.push('>');
		
		if(this.NullValue.length)
			tmp.push("<option value=\""+this.NullValue[Math.min(this.NullValue.length-1,depth)][0]+"\">"+this.NullValue[Math.min(this.NullValue.length-1,depth)][1]+"</option>");
		
		if(Node!=null)
			for(var i=0;i<Node.childNodes.length;i++){
				var cNode = Node.childNodes[i];
				tmp.push('<option value="'+cNode.getAttribute(this.AttrValueField)+'"');
				if(cNode.getAttribute(this.AttrValueField) == SelectedValue)tmp.push(' selected');
				tmp.push('>'+cNode.getAttribute(this.AttrTextField)+'</option>');
			}
		tmp.push('</select>');
		return tmp.join('');
	}

	
	this.write=function(){
		if(this._Data==null){
			alert("数据源加载错误。");
			return;
		}
		if(this.MaxDepth!=null && this.MaxDepth<this.ShowSelectsCount){
			alert("参数错误！\n\n当设置了默认显示多少个多选框时(ShowSelectsCount),最多显示多少级(MaxDepth) 必须大于 设置一开始显示多少个多选框(ShowSelectsCount)。");
			return;
		}
		
		this.NowNode = (this.DefaultValue == this.LoadDataByParentId || this.DefaultValue == "" || this.DefaultValue == null)?null:this.LoadNode(this.DefaultValue);
		this.RootNode = this.LoadDataByParentId==null?this._Data:this.LoadNode(this.LoadDataByParentId);
		this.ClassRoute = this.LoadClassRoute();
		
		var  s = new Array();
		
		s.push('<input type="hidden" id="'+this.SelectName+'" name="'+this.SelectName+'" value="'+(this.DefaultValue==null?"":this.DefaultValue)+'" text="'+(this.NowNode==null?"":this.NowNode.getAttribute(this.AttrTextField))+'" />');
		s.push('<div id="'+this.SelectName+'_" name="'+this.SelectName+'_">');
		
		for(var i=0; i< this.ClassRoute.length; i++){
			if(i==0 || (i!=0 && this.LoadNode(this.ClassRoute[i].value).childNodes.length))
				s.push(
					this.GetSelect(
						this.ClassRoute[i].value==null?this._Data:this.LoadNode(this.ClassRoute[i].value),
						(this.ClassRoute.length > (i+1))?this.ClassRoute[i+1].value:null,
						i
					)
				);
			if(this.MaxDepth!=null && i==(this.MaxDepth-1)){
				this.ClassRoute.splice(i+2,this.ClassRoute.length)
				break;
			}
		}
		for(var i=0;i<(this.ShowSelectsCount-this.ClassRoute.length);i++)
			s.push(this.GetSelect(null,"",this.ClassRoute.length+i));

		s.push('</div>');
		
		document.write(s.join(""));
		
		var me = this;
		var obj;
		for(var i=0;i<this.$(this.SelectName+'_').childNodes.length;i++){
			obj = null;
			obj = this.$(this.SelectName+'_').childNodes[i];
			if(obj.tagName=="SELECT"){
				if(obj.attachEvent){
					obj.attachEvent("onchange", (function(){
    					var t = this;
    					return function(){ me.changeSelect(t); }
					}).call(obj));
				}else if(obj.addEventListener){
					obj.addEventListener("change", (function(){
    					var t = this;
    					return function(){ me.changeSelect(t); }
					}).call(obj),false);
				}
			}
		}
	}


	this.IsNullSelect=function(oSelect){
		if(this.NullValue.length)
			return (oSelect.options.length==1)?true:false;
		else
			return (oSelect.options.length==0)?true:false;
	}
	
	this.IsSelectValue=function(oSelect){
		if(this.NullValue.length)
			return (oSelect.selectedIndex<1)?false:true;
		else
			return (oSelect.selectedIndex<0)?false:true;
	}
	
	this.GetSelectByDepth=function(_depth){
		try{
			return this.$(this.SelectName+"_").childNodes(_depth);
		}
		catch(e){
			return null;
		}
	}
	
	this.GetLastSelect=function(){
		try{
			var Childs = this.$(this.SelectName+"_").childNodes;
			for(var i=Childs.length;i>0;i--)
				if(!this.IsNullSelect(Childs[i-1]))
					return Childs[i-1];
		}
		catch(e){
			return null;
		}
	}
	
	this.AlertRoute = function(){
		var s = new Array();
		for(var i=0;i<this.ClassRoute.length;i++)
			s.push(this.ClassRoute[i].value+"\t"+this.ClassRoute[i].text+"\n\n");
		alert(s.join(""));
	}
	
	//以下是Select联动操作
	this.removeSelect = function(_select){
		var oSpan = this.$(this.SelectName+"_");
		for(var i=oSpan.childNodes.length;i>0;i--){
			if(oSpan.childNodes[i-1]==_select)
				break;
			else{
				//开始判断；如果>ShowSelectsCount 则直接remove;否则执行清空select
				var oSelect = oSpan.childNodes[i-1];
				if(i<=this.ShowSelectsCount){
					if(this.NullValue.length)
						for(var n=oSelect.length;n>0;n--)oSelect.options[n]=null;
					else
						oSelect.innerHTML="";
					oSelect.selectedIndex=-1;
				}
				else
					oSpan.removeChild(oSelect);
			}
		}
	}
	this.changeSelect = function(oSelect){
		var oSpan = this.$(this.SelectName+"_");
		var _selectIndex = 0;
		//开始重新计算 ClassRoute 以及NowNode
		for(var i=0;i<oSpan.childNodes.length;i++){
			if(oSpan.childNodes[i] != oSelect)continue;
			_selectIndex = i;
			if(this.IsSelectValue(oSelect)){
				this.ClassRoute.splice(i+1,this.ClassRoute.length);
				this.ClassRoute.push({value:oSelect.value,text:oSelect.options[oSelect.selectedIndex].text});
				this.NowNode = this.LoadNode(oSelect.value);
			}
			else{
				this.ClassRoute.splice(i+1,this.ClassRoute.length);
				this.NowNode = this.ClassRoute[this.ClassRoute.length-1].value==null?this.RootNode:this.LoadNode(this.ClassRoute[this.ClassRoute.length-1].value);
			}
			break;
		}
		
		
		
		this.$(this.SelectName).value = this.ClassRoute[this.ClassRoute.length-1].value;
		this.$(this.SelectName).setAttribute("text",this.ClassRoute[this.ClassRoute.length-1].text);
		
		
		if(oSelect.value == "" || this.LoadNode(oSelect.value)==null || this.LoadNode(oSelect.value).childNodes.length == 0){
			// 清除位置在自己后面的select
			this.removeSelect(oSelect);
		}
		else{
			if(oSpan.lastChild == oSelect){
				//appendChild
				if(this.MaxDepth==null || oSpan.childNodes.length < this.MaxDepth){
					oSpan.insertAdjacentHTML("beforeEnd",this.GetSelect(this.LoadNode(oSelect.value),null,_selectIndex+1));
					var me = this;
					var obj = oSpan.lastChild;
					if(obj.attachEvent){
						obj.attachEvent("onchange", (function(){
	    					var t = this;
	    					return function(){ me.changeSelect(t); }
						}).call(obj));
					}else if(obj.addEventListener){
						obj.addEventListener("change", (function(){
	    					var t = this;
	    					return function(){ me.changeSelect(t); }
						}).call(obj),false);
					}
				}
			}
			else{
				//removeChild And modify child  
				var _selectNextNode = null;
				_selectNextNode = oSpan.childNodes[_selectIndex+1];
				this.removeSelect(_selectNextNode);
				if(this.NullValue.length)
					for(var n=_selectNextNode.length;n>0;n--)_selectNextNode.options[n]=null;
				else
					_selectNextNode.innerHTML="";
				if(this.MaxDepth==null || _selectIndex<(this.MaxDepth-1)){
					var tmp="",i=0,Nodes;
					Nodes = this.LoadNode(oSelect.value).childNodes;
					for(var n=0;n<Nodes.length;n++){
						var op = document.createElement("OPTION");
						op.text = Nodes[n].getAttribute(this.AttrTextField);
						op.value = Nodes[n].getAttribute(this.AttrValueField);
						_selectNextNode.options.add(op);
					}
				}
			}
		}
	}
}