import datetime

class DVD:

    def __init__(self, name: str, id_: int, creation_year: int, creation_month: str, age_restriction: int):
        self.name = name
        self.id = id_
        self.creation_year = creation_year
        self.creation_month = creation_month
        self.age_restriction = age_restriction
        self.is_rented = False

    @classmethod
    def from_date(cls, id_: int, name: str, date: str, age_restriction: int):
        date_args = date.split('.')
        day = int(date_args[0])
        month = int(date_args[1])
        year = int(date_args[2])
        creation_month = datetime.date(year, month, day).strftime('%B')

        new_dvd = cls(name, id_, year, creation_month, age_restriction)

        return new_dvd

    def __repr__(self):
        status = 'not rented'
        if self.is_rented:
            status = 'rented'

        return f'{self.id}: {self.name} ({self.creation_month} {self.creation_year}) has age restriction {self.age_restriction}. Status: {status}'
