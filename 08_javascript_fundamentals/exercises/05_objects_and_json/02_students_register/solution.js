function solve() {
    document.querySelector('#button').addEventListener('click', addStudents);

    const students = [];
    function addStudents(event) {
        event.preventDefault();

        const inputArgs = document.querySelector('#input').value.split('\n');

        for (let student of inputArgs) {
            const studentArgs = student.split(' ');
            const firstName = studentArgs[0];
            const lastName = studentArgs[1];
            const grade = +studentArgs[2];

            students.push({fullName: `${firstName} ${lastName}`, grade});
        }

        const studentNames = students.map(x => x.fullName).join(', ');
        const avgGrade = students
            .map(s => s.grade)
            .reduce((prev, curr) => prev + curr, 0) / students.length;

        let result =
            `Students are: ${studentNames}\n` +
            `Average grade: ${avgGrade.toFixed(2)}`;

        document.querySelector('#result').value = result;
    }
}