/*
- jquery adds to window object -> window.$ = jquery
- jquey methods could be chained
- to get native HTMLElement from $() use .get(index)
- to get jquery element use .eq(index)
- methods will apply over all selected elements with $()
- methods:
    - css('key', 'value')
        - css({'key': vlaue, 'key2': value2})
    - html(val) = .innerhtml = val
    - text() = .innertext
    - click(function) = .onclick
- $().filter(":eq(0),:eq(1)") -> select first two elements
    - filter(function(this)) -> use this as native element to return boolean
*/