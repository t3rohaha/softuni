class Profile():
    def __init__(self, username, password):
        self.set_username(username)
        self.set_password(password)

    def get_username(self):
        return self._username

    def set_username(self, value):
        if len(value) >= 5 and len(value) <= 15:
            self._username = value
        else:
            raise ValueError('The username must be between 5 and 15 characters.')

    def get_password(self):
        return self._password

    def set_password(self, value):
        min_length = len(value) >= 8
        has_upper = any(c.isupper() for c in value)
        has_digit = any(c.isdigit() for c in value)

        if min_length and has_upper and has_digit:
            self._password = value
        else:
            raise ValueError('The password must be 8 or more characters with at least 1 digit and 1 uppercase letter.')

    def __str__(self):
        return f'You have a profile with username: "{self._username}" and password: {"*"*len(self._password)}'


try:
    profile_with_invalid_password = Profile('My_username', 'My-password')
    profile_with_invalid_username = Profile('Too_long_username', 'Any')
    correct_profile = Profile("Username", "Passw0rd")
    print(correct_profile)
except ValueError as er:
    print(er)
