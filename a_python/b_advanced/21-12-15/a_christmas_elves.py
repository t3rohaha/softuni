from collections import deque

def christmas_elves():
    elves = deque(map(int, input().split()))        # elves queue
    materials = list(map(int, input().split()))     # materials stack
    energy = 0                                      # total energy spent
    toys = 0                                        # total toys created
    counter = 0                                     # materials taken

    while elves and materials:
        first_elf = elves.popleft()
        if first_elf < 5:
            continue                            # take a day off
        counter += 1                            # elf take material
        last_material = materials.pop()
        toys_created = 1
        energy_needed = last_material

        if counter % 3 == 0:
            energy_needed *= 2                  # double energy needed
            toys_created = 2                    # double toys created

        if counter % 5 == 0:
            toys_created = 0                    # elf breaks toys

        if first_elf >= energy_needed:
            toys += toys_created                # increase toys created
            first_elf -= energy_needed          # decrease elf energy
            energy += energy_needed             # increase total energy spent
            if toys_created:
                first_elf += 1                  # give reward
        else:
            materials.append(last_material)     # leave work to next elf
            first_elf *= 2                      # double up energy

        elves.append(first_elf)                 # go last

    print(f'Toys: {toys}')
    print(f'Energy: {energy}')
    if elves:
        print(f'Elves left: {", ".join(map(str, elves))}')
    if materials:
        print(f'Boxes left: {", ".join(map(str, materials))}')

christmas_elves()
