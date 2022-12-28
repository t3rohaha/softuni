def add_songs(*t):
    songs = {}
    for title, lyrics in t:
        if title not in songs:
            songs[title] = []
        songs[title].extend(lyrics)

    output = ''
    for title, lyrics in songs.items():
        output += f'- {title}\n'
        for l in lyrics:
            output += f'{l}\n'

    return output.strip()

