from project.song import Song

class Album:
    def __init__(self, name, *songs):
        self.name = name
        self.songs = list(songs)
        self.published = False

    def add_song(self, song):
        if not song.single:
            if not self.published:
                if song not in self.songs:
                    self.songs.append(song)
                    return f'Song {song.name} has been added to the album {self.name}.'
                return f'Song is already in the album.'
            return f'Cannot add songs. Album is published.'
        return f'Cannot add {song.name}. It\'s a single'

    def remove_song(self, song_name):
        if not self.published:
            for s in self.songs:
                if song_name == s.name:
                    self.songs.remove(s)
                    return f'Removed song {song_name} from album {self.name}.'
            return f'Song is not in the album.'
        return f'Cannot remove songs. Album is published.'

    def publish(self):
        if not self.published:
            self.published = True
            return f'Album {self.name} has been published.'
        return f'Album {self.name} is already published.'

    def details(self):
        info = f'Album {self.name}'
        for s in self.songs:
            info += f'\n== {s.get_info()}'
        return info
