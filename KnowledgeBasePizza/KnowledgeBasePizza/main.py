
# Pizza types and their conditions
pizza_conditions = {
    'margherita': {
        'why': 'hungry',
        'smt_exotic': 'no',
        'pepper': 'yes',
        'hot': 'not_bad',
        'meat': 'hate'
    },
    'meats': {
        'why': 'hungry',
        'meat': 'love',
        'hot': 'love'
    },
    'calzone': {
        'smt_exotic': 'yes',
        'pepper': 'yes',
        'hot': 'not_bad',
        'meat': 'love'
    },
    'veg': {
        'meat': 'hate',
        'smt_sweet': 'no'
    },
    'hawaiian': {
        'why': 'for_fun',
        'smt_exotic': 'yes',
        'smt_sweet': 'yes',
        'meat': 'love',
        'pepper': 'yes'
    },
    'cheese_bomb': {
        'cheese': 'im_a_fan'
    },
    'diablo': {
        'why': 'for_fun',
        'pepper': 'yes',
        'hot': 'im_a_fan',
        'meat': 'love'
    },
    'paradize': {
        'why': 'for_fun',
        'smt_exotic': 'yes',
        'smt_sweet': 'yes'
    }
}

# Questions
questions = {
    'fav_ing': 'What is your favorite ingredient?',
    'why': 'Why do you want a pizza?',
    'cheese': 'How much do you love cheese?',
    'smt_sweet': 'Do you want something sweet?',
    'smt_exotic': 'Do you love something exotic?',
    'pepper': 'Do you love pepper?',
    'hot': 'How much do you love something hot?',
    'meat': 'How much do you love meat?'
}

# Answers
answers = {
    'for_fun': 'For fun',
    'i_dont_know': 'I don\'t know',
    'hungry': 'I\'m hungry',
    'hate': 'Hate',
    'love': 'Love',
    'yes': 'Yes',
    'no': 'No',
    'im_a_fan': 'I\'m a fan!',
    'not_bad': 'Not bad',
    'meat': 'Meat',
    'vegetables': 'Vegetables',
    'pepper': 'Pepper',
    'cheese': 'Cheese'
}

pizzas = {
    "margarita": {
        "description": "Pizza Margherita\nThe pizza Margherita is just over a century old and is named after HM Queen Margherita of Italy, wife of King Umberto I and first Queen of Italy. It's made using toppings of tomato, mozzarella cheese, and fresh basil, which represent the red, white, and green of the Italian flag."
    },
    "cheese_bomb": {
        "description": "Pizza Cheese Bomb\nParmesan, Romano, Fontina, Gouda, Ricotta & Mozzarella Cheeses on an Alfredo Sauce"
    },
    "calzone": {
        "description": "Pizza Calzone\nCalzone means 'stocking' in Italian and is a turnover that originates from Italy. Shaped like a semicircle, the calzone is made of dough folded over and filled with the usual pizza ingredients."
    },
    "veg": {
        "description": "Vegetarian pizza\nTomatoes, mushrooms, green peppers, onions, black olives on zesty red sauce."
    },
    "hawaiian": {
        "description": "Hawaiian pizza\nTender ham & juicy pineapple on zesty red sauce."
    },
    "paradize": {
        "description": "Paradize pizza\nRicotta, cherry, mint, strawberry."
    },
    "diablo": {
        "description": "Diablo pizza\nOnion, Red Pepper, Cherry Tomatoes, Broccoli & Mushrooms, Marinara, Mozzarella & Parmesan"
    },
    "meats": {
        "description": "The Ultimate in Premium Meats\nPrimo pepperoni, linguica, bacon, Italian sausage on zesty red sauce."
    }
}

progress = {}


def introduction():
    print('What kind of pizza do I want?')
    print()


def smt_sweet():
    answer = None
    while answer not in ['yes', 'no', 'i_dont_know']:
        answer = input(f"{questions['smt_sweet']} (yes/no/i_dont_know) ")
    if answer not in ['yes', 'no', 'i_dont_know']:
        print("Invalid answer. Please answer with 'yes', 'no', or 'i_dont_know'")
    return answer


def why():
    answer = None
    while answer not in ['for_fun', 'hungry']:
        answer = input(f"{questions['why']} (for_fun/hungry) ")
    if answer not in ['for_fun', 'hungry', 'i_dont_know']:
        print("Invalid answer. Please answer with 'for_fun', 'hungry'")
    return answer


def smt_exotic():
    answer = None
    while answer not in ['yes', 'no']:
        answer = input(f"{questions['smt_exotic']} (yes/no) ")
    if answer not in ['yes', 'no', 'i_dont_know']:
        print("Invalid answer. Please answer with 'yes', 'no'")
    return answer


def pepper():
    answer = None
    while answer not in ['yes', 'no', 'i_dont_know']:
        answer = input(f"{questions['pepper']} (yes/no/i_dont_know) ")
    if answer not in ['yes', 'no', 'i_dont_know']:
        print("Invalid answer. Please answer with 'yes', 'no', or 'i_dont_know'")
    return answer


def hot():
    answer = None
    while answer not in ['love', 'not_bad', 'hate', 'i_dont_know']:
        answer = input(f"{questions['hot']} (love/not_bad/hate/i_dont_know) ")
    if answer not in ['love', 'not_bad', 'hate', 'i_dont_know']:
        print("Invalid answer. Please answer with 'love', 'not_bad', 'hate', or 'i_dont_know'")
    return answer


def meat():
    answer = None
    while answer not in ['love', 'not_bad', 'hate', 'i_dont_know']:
        answer = input(f"{questions['meat']} (love/not_bad/hate/i_dont_know) ")
    if answer not in ['love', 'not_bad', 'hate', 'i_dont_know']:
        print("Invalid answer. Please answer with 'love', 'not_bad', 'hate', or 'i_dont_know'")
    return answer


def cheese():
    answer = None
    while answer not in ['im_a_fan', 'not_bad', 'hate', 'i_dont_know']:
        answer = input(f"{questions['cheese']} (im_a_fan/not_bad/hate/i_dont_know) ")
    if answer not in ['im_a_fan', 'not_bad', 'hate', 'i_dont_know']:
        print("Invalid answer. Please answer with 'im_a_fan', 'not_bad', 'hate', or 'i_dont_know'")
    return answer


def find_pizza():
    if why() == 'hungry' and smt_exotic() == 'no' and pepper() == 'yes' and hot() == 'not_bad' and meat() == 'hate' and cheese() == 'im_a_fan':
        return pizzas['margarita']['description']
    elif why() == 'hungry' and meat() == 'love' and hot() == 'love':
        return pizzas['meats']['description']
    elif smt_exotic() == 'yes' and pepper() == 'yes' and hot() == 'not_bad' and meat() == 'not_bad':
        return pizzas['calzone']['description']
    elif meat() == 'hate' and smt_sweet() == 'no':
        return pizzas['veg']['description']
    elif why() == 'for_fun' and smt_exotic() == 'yes' and smt_sweet() == 'yes' and meat() == 'not_bad' and pepper() == 'yes':
        return pizzas['hawaiian']['description']
    elif cheese() == 'im_a_fan':
        return pizzas['cheese_bomb']['description']
    elif why() == 'for_fun' and pepper() == 'yes' and hot() == 'love' and meat() == 'love':
        return pizzas['diablo']['description']
    elif why() == 'for_fun' and smt_exotic() == 'yes' and smt_sweet() == 'yes':
        return pizzas['paradize']['description']
    else:
        return 'Sorry, cannot recommend pizza with your preferences'


# Ask a question
def ask(question, options):
    print(questions[question])
    for i, option in enumerate(options):
        print(f'{i + 1}. {answers[option]}')
    answer = input()
    while not answer.isdigit() or int(answer) < 1 or int(answer) > len(options):
        print('Invalid answer, please try again')
        answer = input()
    progress[question] = options[int(answer) - 1]
    return progress[question]


def main():
    introduction()
    pizza = find_pizza()
    print(f"You should try {pizza} pizza!")


if __name__ == "__main__":
    main()
