from project.task import Task

class Section:
    def __init__(self, name):
        self.name = name
        self.tasks = []

    def add_task(self, new_task):
        if new_task in self.tasks:
            return f'Task is already in the section {self.name}'
        self.tasks.append(new_task)
        return f'Task {new_task.details()} is added to the section'

    def complete_task(self, task_name):
        if task_name not in [t.name for t in self.tasks]:
            return f'Could not find task with the name {task_name}'

        for t in self.tasks:
            if t.name == task_name:
                t.completed = True
                return f'Completed task {task_name}'

    def clean_section(self):
        counter = 0
        for t in self.tasks:
            if t.completed:
                del t
                counter += 1

        return f'Cleared {counter} tasks.'

    def view_section(self):
        output = f'Section {self.name}:'
        for t in self.tasks:
            output += f'\n{t.details()}'

        return output
