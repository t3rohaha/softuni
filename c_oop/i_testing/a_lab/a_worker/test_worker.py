import unittest
from worker import Worker   # remove before submission

class WorkerTests(unittest.TestCase):

    def test_worker_initialization(self):
        worker = Worker('Gosho', 600, 0)
        self.assertEqual(worker.name, 'Gosho')
        self.assertEqual(worker.salary, 600)
        self.assertEqual(worker.energy, 0)

    def test_worker_rest(self):
        worker = Worker('Gosho', 600, 0)
        worker.rest()
        energy_after_rest = worker.energy
        self.assertEqual(energy_after_rest, 1)

    def test_worker_work_with_invalid_energy(self):
        worker = Worker('Gosho', 600, 0)
        self.assertEqual(worker.energy, 0)
        with self.assertRaises(Exception) as ex:
            worker.work()
        self.assertEqual(str(ex.exception), 'Not enough energy.')

    def test_worker_work_money(self):
        worker = Worker('Gosho', 600, 1)
        worker.work()
        result = worker.money
        self.assertEqual(result, 600)

    def test_worker_work_energy(self):
        worker = Worker('Gosho', 600, 1)
        worker.work()
        result = worker.energy
        self.assertEqual(result, 0)

    def test_worker_get_info(self):
        worker = Worker('Gosho', 600, 1)
        worker.work()
        result = worker.get_info()
        self.assertEqual(result, 'Gosho has saved 600 money.')


if __name__ == '__main__':
    unittest.main()

