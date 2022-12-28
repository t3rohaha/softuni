company_name = input()
adult_tickets = int(input())
children_tickets = int(input())
ticket_price = float(input())
service_price = float(input())

parents_total = adult_tickets * (ticket_price + service_price)
children_total = children_tickets * (ticket_price * 0.3 + service_price)
profit = (parents_total + children_total) * 0.2

print(f'The profit of your agency from {company_name} tickets is {profit:.2f} lv.')

