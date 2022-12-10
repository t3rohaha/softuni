def stock_availability(boxes, service, *args):
    if service == 'delivery':
        boxes.extend(args)
    else:
        if args:
            if type(args[0]) == int:
                del boxes[:args[0]]
            else:
                for cake in args:
                    if cake in boxes:
                        boxes = [c for c in boxes if c != cake]
        else:
            del boxes[0]

    return boxes

