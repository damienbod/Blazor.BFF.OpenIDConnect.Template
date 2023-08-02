function getAntiForgeryToken() {
    var elements = document.getElementsByName('__RequestVerificationToken');

    // There can be two __RequestVerificationToken inputs. 
    elements = Array.prototype.slice.call(elements).sort(function (a, b) {
      return b.value.length - a.value.length;
    });
    
    if (elements.length > 0) {
        return elements[0].value
    }

    console.warn('no anti forgery token found!');
    return null;
}
