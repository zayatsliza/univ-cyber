import networkx as nx
import matplotlib.pyplot as plt
import networkx.algorithms as nxa
import networkx.algorithms.approximation as nxaa
import numpy as np
import io


if __name__ == '__main__':
    data = {
        'weights': list(),
        'edges': list()
    }
    file = io.FileIO("graph.txt", 'r')
    content = file.read().decode('utf-8')
    rows = list(content.strip().split('\n'))
    for i in rows:
        i = list(i.strip().split(':'))
        w = int(i[0])
        e = list(map(lambda s: int(s.strip()), i[1].strip().split(',')))
        data['weights'].append(w)
        data['edges'].append(e)

    adj_matrix = np.matrix(data['edges'])

    plt.title('Граф')
    G = nx.Graph(adj_matrix)
    for i in range(len(data['weights'])):
        G.nodes[i]['weight'] = data['weights'][i]
    pos = nx.spring_layout(G)
    nx.draw(G, pos, with_labels=True)
    labels = nx.get_edge_attributes(G, 'weight')
    nx.draw_networkx_edge_labels(G, pos, edge_labels=labels)
    plt.show()

    nx.draw(G, pos, with_labels=True)
    max_w_match = nx.max_weight_matching(G, maxcardinality=False, weight='weight')
    print("Максимальне зважене паросполучення (реберне пакування)", max_w_match)
    plt.title('Максимальне зважене паросполучення (реберне пакування)')
    Gr = nx.Graph()
    Gr.add_edges_from(max_w_match)
    nx.draw_networkx_nodes(Gr, pos, node_color='g')
    nx.draw_networkx_edges(Gr, pos, edge_color='g')
    plt.show()

    plt.title('Максимальна зважена незалежна множина вершин (вершинне пакування)')
    nx.draw(G, pos, with_labels=True)
    max_independent_set = nx.maximal_independent_set(G)
    print("Максимальна зважена незалежна множина вершин (вершинне пакування)",
          max_independent_set)
    Gr = nx.Graph()
    Gr.add_nodes_from(max_independent_set)
    nx.draw_networkx_nodes(Gr, pos, node_color='g')
    plt.show()

    plt.title('Мiнiмальне зважене реберне покриття')
    min_edge_cover = nx.min_edge_cover(G)
    nx.draw(G, pos, with_labels=True)
    print("Мiнiмальне зважене реберне покриття", min_edge_cover)
    Gr = nx.Graph()
    Gr.add_edges_from(min_edge_cover)
    nx.draw_networkx_edges(Gr, pos, edge_color='g')
    plt.show()

    plt.title('Мiнiмальне зважене вершинне покриття')
    min_node_cover = nxaa.min_weighted_vertex_cover(G)
    print("Мiнiмальне зважене вершинне покриття", min_node_cover)
    nx.draw(G, pos, with_labels=True)
    Gr = nx.Graph()
    Gr.add_nodes_from(min_node_cover)
    nx.draw_networkx_nodes(Gr, pos, node_color='g')
    plt.show()

    cliques = nxa.max_weight_clique(G)
    nx.draw(G, pos, with_labels=True)
    print("Максимальний зважений повний пiдграф (клiка) зважене вершинне покриття", cliques)
    plt.title('Максимальний зважений повний пiдграф (клiка) зважене вершинне покриття')
    Gr = G.subgraph(cliques[0])
    nx.draw_networkx_nodes(Gr, pos, node_color='g')
    nx.draw_networkx_edges(Gr, pos, edge_color='g')
    plt.show()

    plt.title('Мiнiмальна правильна розфарбовка вершин')
    min_color = nx.greedy_color(G)
    print("Мiнiмальна правильна розфарбовка вершин", min_color)
    color_map = [0] * len(G.nodes)
    for i, c in min_color.items():
        color_map[i] = c
    nx.draw(G, pos, with_labels=True, node_color=color_map)
    Gr = nx.Graph()
    plt.show()

    plt.title('Мiнiмальне зважене остовне дерево')
    minimum_spanning_tree = nx.minimum_spanning_tree(G)
    nx.draw(G, pos, with_labels=True)
    print("Мiнiмальне зважене остовне дерево", minimum_spanning_tree)
    nx.draw_networkx_edges(minimum_spanning_tree, pos, edge_color='g', arrows=False)
    plt.show()

    print(f"Ексцентриситет {nx.eccentricity(G)} \n")

