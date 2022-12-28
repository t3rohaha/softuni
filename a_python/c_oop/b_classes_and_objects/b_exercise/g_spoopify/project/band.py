from project.album import Album

class Band:
    def __init__(self, name):
        self.name = name
        self.albums = []

    def add_album(self, album):
        if album not in self.albums:
            self.albums.append(album)
            return f'Band {self.name} has added their newest album {album.name}.'
        return f'Band {self.name} already has {album.name} in their library.'

    def remove_album(self, album_name):
        for a in self.albums:
            if album_name == a.name:
                if not a.published:
                    self.albums.remove(a)
                    return f'Album {album_name} has been removed.'
                return 'Album has been published. It cannot be removed.'
        return f'Album {album_name} is not found.'

    def details(self):
        info = f'Band {self.name}'
        for a in self.albums:
            info += f'\n{a.details()}'
        return info
