import math

class PhotoAlbum:

    def __init__(self, pages: int):
        self.pages = pages
        self.photos = self.initialize_photos()

    @classmethod
    def from_photos_count(cls, photos_count: int):
        return cls(math.ceil(photos_count/4))

    def add_photo(self, label: str):
        if self.is_full():
            return 'No more free slots'

        for p in self.photos:
            if len(p) != 4:
                p.append(label)
                return f'{label} photo added successfully on page {self.photos.index(p)+1} slot {len(p)}'

    def initialize_photos(self):
        photos = []
        for _ in range(self.pages):
            photos.append([])
        return photos

    def is_full(self):
        return len(self.photos[-1]) == 4

    def display(self):
        SEP = '-' * 11
        NL = '\n'
        output = ''
        for p in self.photos:
            temp_photos = []
            for ph in p:
                temp_photos.append('[]')
            output += SEP + NL
            output += ' '.join(temp_photos) + NL
        output += SEP
        return output

