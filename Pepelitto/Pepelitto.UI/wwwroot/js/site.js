function sendServerFunc(url_path, obj, success_func, error_func) { 
    $.ajax({
        url: url_path,
        type: "POST",
        dataType: "json",

        data: obj,
        success: error_func
    });
}
class FlagIcon extends HTMLElement {
    constructor() {
        super();
        this._countryCode = null;
    }

    static observedAttributes = ["country"];

    attributeChangedCallback(name, oldValue, newValue) {
        // name will always be "country" due to observedAttributes
        this._countryCode = newValue;
        this._updateRendering();
    }
    connectedCallback() {
        this._updateRendering();
    }

    get country() {
        return this._countryCode;
    }
    set country(v) {
        this.setAttribute("country", v);
    }

    _updateRendering() {
        // Left as an exercise for the reader. But, you'll probably want to
        // check this.ownerDocument.defaultView to see if we've been
        // inserted into a document with a browsing context, and avoid
        // doing any work if not.
    }
} 
customElements.define("flag-icon", FlagIcon);
class Dialog { 
    innerhtml = ""; 
    dialogID = "";
    activeElement;

    Dialog(html,id) {
        this.innerhtml = html;
        this.dialogID = id;
    } 
    showDialog() {
        this.activeElement = document.createElement("div");
        this.activeElement.innerhtml = this.innerhtml;
        document.body.appendChild(this.activeElement);
        this.activeElement.removeAttribute("hidden");
        
    } 
    closeDialog() { 
        this.activeElement.remove();
    }
}; 

var dialogs = [];
/*function refresh() {
    try {
        var header = document.getElementsByClassName("header")[0];
        var leftside = document.querySelector('.sideNav[alg="left"');
        var rightside = document.querySelector('.sideNav[alg="right"');
        var content = document.getElementsByClassName("content")[0];
        content.style.paddingTop = header.style.height + "px";
    } catch { 

    }
     
    

}
window.addEventListener("resize", () => { refresh(); });*/
/*window.addEventListener("load", (element, obj) => {
    refresh(); 
    const flagIcon = document.createElement("flag-icon");
    flagIcon.country = "jp";
    document.body.appendChild(flagIcon); 
    const post_write = document.createElement("post-write");
    document.body.appendChild(post_write);
    var df = document.querySelector("body");
    var modals = document.querySelectorAll(".modal-parent");
    
    for (var index = 0; index < modals.length; index++) {

        dialogs.push(new Dialog(modals[index].innerHTML, modals[index].getAttribute("modal-id")));
        
        modals[index].remove();
    }
    
    function showModal(id) {
        var len =dialogs.length; 
        for (var i = 0; i < len; i++) {
            var modal = dialogs[i];
            if (modal.dialogID == id) {
                modal.showDialog();
            }
        }
        
    } 

});*/
class PostWriter {
    constructor() {
        var post_writer = document.getElementsByClassName(".post-writer")[0];
        var post_content = post_writer.getElementsByClassName(".post-content")[0];
        var bold_button = post_writer.getElementsByClassName("bold-button")[0];
        
        bold_button.addEventListener("load", () => {
            selection= document.getSelection();
        });
    } 
    
}
class PostWrite extends HTMLDivElement {
   
    
    init() {
        this.onload = function hh() { alert("bidaa"); };
        var fg = new HTMLVideoElement(); 
        fg.get
        window.addEventListener("load", () => { 
            
            var post_writer = this;
            var post_content = post_writer.getElementsByClassName("post-content")[0];
            var bold_button = post_writer.getElementsByClassName("bold-button")[0]; 
            var italic_button = post_writer.getElementsByClassName("italic-button")[0];
            post_content.contentEditable = "true";
            italic_button.addEventListener("click", () => {
                var selection = document.getSelection();
                if (selection.focusNode.parentElement == post_content) { 
                    
                    for (var i = 0; i < selection.rangeCount; i++) { 
                        var range = selection.getRangeAt(i);
                        
                        var element = document.createElement("span");
                        element.classList.add("edit");
                        element.style.fontStyle = "italic"; 
                        try {
                            range.surroundContents(element);
                        }
                        catch {
                            let text = selection.focusNode.parentElement.innerText;
                            selection.focusNode.parentElement.innerHTML = element.innerHTML;
                            selection.focusNode.parentElement.innerText = text;
                        }
                    }
                    
                    
                }
            });
            bold_button.addEventListener("click", () => {
                    var selection = document.getSelection();

                if (selection.focusNode.parentElement == post_content) { 
                    var range = selection.getRangeAt(0);
                    var element = document.createElement("span");
                    element.classList.add("edit");
                    element.style.fontWeight = "bold"; 
                    try {
                        range.surroundContents(element);
                    }
                    catch {
                        let text = selection.focusNode.parentElement.innerText;
                        selection.focusNode.parentElement.innerHTML = element.innerHTML;
                        selection.focusNode.parentElement.innerText = text;
                    }
                    
                }
                    
                
            });
            
        });
     
    } 
    isselected(s) {
        return s.focusNode.parentElement.classList.contains("edit");
    }
    connectedCallback() {
        this.init();
        
    }
    sendpost() { 

    }
    disconnectedCallback() {
       
    }

    adoptedCallback() {
        
    }

    attributeChangedCallback(name, oldValue, newValue) {
        
    } 

} 

customElements.define("post-write", PostWrite, { extends: "div" }); 
class DashButton {
    dashboard = undefined;
    button = undefined;
    btns = [];
    dashcontent = undefined;
    viewname = "a";
    constructor(dashElement, content, btn, buttons) {
        this.dashboard = dashElement;
        this.button = btn;
        this.dashcontent = content;
        this.btns = buttons;
        this.button.addEventListener("click", this.click);
        this.viewname = this.button.getAttribute("view");
    }
    click() {
        var child = dashcontent.children; 
        
        for (var i = 0; i < child.length; i++) {
            var view = child[i];
            if (view.id != this.viewname) {
                view.setAttribute("hidden", ""); 
                
                
            } else {
                view.removeAttribute("hidden");
            }
        }
        this.button.setAttribute("selected");
        for (var index = 0; index < this.btns.length; index++) {
            if (btns[index] != this.button) {
                if (this.btns[index].hasAttribute("selected")) { 
                    this.btns[index].removeAttribute("selected");
                }
                
            }
        }
    }
}; 
class DropDown extends HTMLDivElement { 
    init() {
        var el = this.parentElement.getBoundingClientRect(); 
        var thiss = this;
        this.style.position = "absolute";
        this.style.top = el.bottom+1;
        this.style.left = el.left;
        this.parentElement.addEventListener("resize",() => {thiss.g});
    }
    connectedCallback() { 
        this.init();
    }
}
class DashBoard extends HTMLDivElement {
     
    init() { 
       

        window.addEventListener("load", () => {
            var dashboard = document.getElementsByClassName("dashboard")[0];
            var content_container = dashboard.getElementsByClassName("dash-content")[0];
            var buttons = dashboard.getElementsByClassName("dashbutton");
            var btns = [];
            var uri = window.URL;
            for (var index = 0; index < buttons.length; index++) {
                btns.push(new DashButton(dashboard, content_container, buttons[index], buttons));
                var buton = buttons[index];
                if (buton.hasAttribute("page-url"))
                {
                    var page_name = buton.getAttribute("page-url"); 
                    if (uri.endsWith(page_name)) {
                        buton.setAttribute("selected");
                    } else {
                        buton.removeAttribute("selected");
                        
                    }
                }
            } 
            
        });
    }
    connectedCallback() { 
        this.init();
    }
}
customElements.define("dash-board", DashBoard, { extends: "div" });


