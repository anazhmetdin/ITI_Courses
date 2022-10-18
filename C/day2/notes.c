/*
    - Operators with same priority have left associtivity, except for assigning operator =
    - compound operators: += -= ...
    - unary operators: ++x, x++
    - prefix ++x is processed first then other operators on the same line
    - parenthesis don't change the order of postfix ++

    - promotion rule: promote datatypes in operator to the highest order

    - else if is a nested if statement inside the else block, the entire block is treated as a single line
    - switch statement creates a jump table to perform a single jump to the condition line directly,
      if no break following lines are executed (fall into/through) could be useful when cases share common body (less readable)
    - default: not a syntax to be the last

    - group switch cases:
        case 1:
        case 2:
        case 3:
            printf("sdfs")
            break;
        ...

    - "for" three statements inside () are optional
        - initialization: first statement could be any thing that will be excuted only once
        - condition: before each iteration
        - increment: after each iteration
    - initialization & increment could have multiple statements sep by ,

    - 1= magic box
        - if x%3 != 0, row-- % col--, else row++
        - gotoxy, 45x80, 10-13-16, 5-7-9 

    - 2= magic box nxn

    ==========
    # Questions
    - how default checks that value is not in jump table in O(1)
*/