/*
- $(function(){}) -> this function will be called when document is loaded

- $('element').next('element') -> selects direct sibling after first element
- $('e').nextAll('e') -> selects all elements after first
- $('e').siblings('e') -> all elements before and after

- $('e', 'parent') -> parent is the context where we select elements, default is root

- $.type() = typeof

- $('selector').each(function(id, element){});
    - or -> $.each($('selector'), function(id, element){});

- $('parent').append($('child')); vs -> $('child').appendTo($('parent'))
    - vs -> prepend() and prependTo()
    - could take element object or html string
    
- $('').on() = .addEventListener()
- $('').off() -> remove
- $('').one() -> one time event

- $().trigger() = .dispatch()
*/