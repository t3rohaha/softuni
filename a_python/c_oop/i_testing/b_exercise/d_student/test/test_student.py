from project.student import Student
from unittest import TestCase, main

class StudentTest(TestCase):

    def test_initialization_default(self):
        student = Student('A')
        self.assertEqual(student.name, 'A')
        self.assertEqual(student.courses, {})

    def test_initialization_with_courses(self):
        courses = {'Course1': ['Notes1', 'Notes2']}
        student = Student('A', courses)
        self.assertEqual(student.name, 'A')
        self.assertEqual(student.courses, {'Course1': ['Notes1', 'Notes2']})

    def test_enroll_existing_course(self):
        courses = {'Course1': ['Notes1', 'Notes2']}
        student = Student('A', courses)
        message = student.enroll('Course1', ['Notes3'])
        self.assertEqual(student.courses, {'Course1': ['Notes1', 'Notes2', 'Notes3']})
        self.assertEqual(message, 'Course already added. Notes have been updated.')

    def test_enroll_new_course_new_notes(self):
        student = Student('A')
        message = student.enroll('Course1', ['Notes1', 'Notes2'])
        self.assertEqual(student.courses, {'Course1': ['Notes1', 'Notes2']})
        self.assertEqual(message, 'Course and course notes have been added.')

    def test_enroll_new_course_new_notes_with_flag(self):
        student = Student('A')
        message = student.enroll('Course1', ['Notes1', 'Notes2'], 'Y')
        self.assertEqual(student.courses, {'Course1': ['Notes1', 'Notes2']})
        self.assertEqual(message, 'Course and course notes have been added.')

    def test_enroll_new_course_ignore_provided_notes_with_flag(self):
        student = Student('A')
        message = student.enroll('Course1', ['Notes1'], 'N')
        self.assertEqual(student.courses, {'Course1': []})
        self.assertEqual(message, 'Course has been added.')

    def test_add_notes_valid_course(self):
        courses = {'Course1': []}
        student = Student('A', courses)
        message = student.add_notes('Course1', 'Notes1')
        self.assertEqual(student.courses, {'Course1': ['Notes1']})
        self.assertEqual(message, 'Notes have been updated')

    def test_add_notes_invalid_course(self):
        student = Student('A')
        with self.assertRaises(Exception) as ex:
            message = student.add_notes('Course1', 'Notes1')
        self.assertEqual(str(ex.exception), 'Cannot add notes. Course not found.')

    def test_leave_course_valid_course(self):
        courses = {'Course1': []}
        student = Student('A', courses)
        message = student.leave_course('Course1')
        self.assertEqual(student.courses, {})
        self.assertEqual(message, 'Course has been removed')

    def test_leave_course_invalid_course(self):
        student = Student('A')
        with self.assertRaises(Exception) as ex:
            message = student.leave_course('Course1')
        self.assertEqual(str(ex.exception), 'Cannot remove course. Course not found.')


if __name__ == '__main__':
    main()

