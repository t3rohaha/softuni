from project.product import Product

class ProductRepository:
    def __init__(self):
        self.products = []

    def add(self, product):
        self.products.append(product)

    def find(self, product_name):
        for p in self.products:
            if p.name == product_name:
                return p

    def remove(self, product_name):
        for p in self.products:
            if p.name == product_name:
                self.products.remove(p)
                break

    def __repr__(self):
        products_info = ''
        for p in self.products:
            products_info += f'{p.name}: {p.quantity}\n'
        return products_info.strip('\n')
