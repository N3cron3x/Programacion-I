import math

# Algoritmo de ordenamiento (Bubble Sort)
def ordenar_lista(lista):
    n = len(lista)
    for i in range(n):
        for j in range(0, n-i-1):
            if lista[j] > lista[j+1]:
                lista[j], lista[j+1] = lista[j+1], lista[j]
    return lista

# Algoritmo de búsqueda (Búsqueda binaria)
def buscar_valor(lista_ordenada, valor):
    izquierda = 0
    derecha = len(lista_ordenada) - 1
    
    while izquierda <= derecha:
        medio = (izquierda + derecha) // 2
        if lista_ordenada[medio] == valor:
            return medio
        elif lista_ordenada[medio] < valor:
            izquierda = medio + 1
        else:
            derecha = medio - 1
    return -1

# Función iterativa
def resolver_logaritmo_iterativo(producto, suma):
    if producto <= 0 or suma <= 0 or producto == 1:
        return None
    
    try:
        base = producto ** (1/suma)
        return base
    except (ValueError, ZeroDivisionError):
        return None

# Función recursiva
def resolver_logaritmo_recursivo(producto, suma, base_ini=1, paso=0.01, precision=0.001, max_iter=100):
    if max_iter <= 0:
        return None
    if producto <= 0 or suma <= 0 or producto == 1:
        return None
    
    valor_calculado = base_ini ** suma
    diferencia = abs(valor_calculado - producto)
    
    if diferencia < precision:
        return base_ini
    elif valor_calculado < producto:
        return resolver_logaritmo_recursivo(producto, suma, base_ini + paso, paso/2, precision, max_iter-1)
    else:
        return resolver_logaritmo_recursivo(producto, suma, base_ini - paso, paso/2, precision, max_iter-1)

def obtener_cuartetos_del_usuario():
    cuartetos = []
    print("Ingrese 4 cuartetos de números (16 números en total):")
    
    for i in range(4):
        while True:
            try:
                entrada = input(f"Cuarteto {i+1} (4 números separados por espacios): ")
                numeros = [float(num) for num in entrada.split()]
                
                if len(numeros) != 4:
                    print("Error: Debe ingresar exactamente 4 números")
                    continue
                
                cuartetos.extend(numeros)
                break
            except ValueError:
                print("Error: Solo se permiten números. Intente nuevamente.")
    
    return cuartetos

def procesar_cuartetos(numeros):
    casos_exitosos = 0
    casos_fallidos = 0
    resultados = []
    bases_encontradas = []
    
    lista_ordenada = ordenar_lista(numeros.copy())
    print(f"\nLista completa ordenada: {lista_ordenada}")
    
    for i in range(0, 16, 4):
        cuarteto = numeros[i:i+4]
        a, b, c, d = cuarteto
        suma = a + d
        producto = b * c
        
        print(f"\nProcesando cuarteto {i//4 + 1}: {cuarteto}")
        print(f"Suma (a + d): {a} + {d} = {suma}")
        print(f"Producto (b * c): {b} * {c} = {producto}")
        
        base_iter = resolver_logaritmo_iterativo(producto, suma)
        base_rec = resolver_logaritmo_recursivo(producto, suma)
        
        if base_iter is not None:
            print(f"Base encontrada (iterativo): {base_iter:.4f}")
            if base_rec is not None:
                print(f"Base encontrada (recursivo): {base_rec:.4f}")
                diferencia = abs(base_iter - base_rec)
                print(f"Diferencia entre métodos: {diferencia:.6f}")
            casos_exitosos += 1
            resultados.append((cuarteto, suma, producto, base_iter))
            bases_encontradas.append(base_iter)
        else:
            print("No se pudo resolver la ecuación logarítmica para este cuarteto")
            casos_fallidos += 1
    
    if bases_encontradas:
        bases_ordenadas = ordenar_lista(bases_encontradas)
        print(f"\nBases encontradas ordenadas: {[f'{b:.4f}' for b in bases_ordenadas]}")
        
        if len(bases_ordenadas) > 0:
            base_media = bases_ordenadas[len(bases_ordenadas)//2]
            posicion = buscar_valor(bases_ordenadas, base_media)
            print(f"Buscando base media: {base_media:.4f} - encontrada en posición {posicion}")
    
    print("\nResumen final:")
    print(f"Total cuartetos procesados: 4")
    print(f"Cuartetos resueltos exitosamente: {casos_exitosos}")
    print(f"Cuartetos no resueltos: {casos_fallidos}")
    
    return resultados

def main():
    print("RESOLUCIÓN DE ECUACIONES LOGARÍTMICAS")
    print("------------------------------------")
    print("Instrucciones:")
    print("- Debe ingresar exactamente 4 cuartetos (16 números en total)")
    print("- Cada cuarteto debe contener 4 números separados por espacios")
    print("- Ejemplo de cuarteto: 2 3 4 5")
    
    numeros = obtener_cuartetos_del_usuario()
    procesar_cuartetos(numeros)
    
    print("\n¿Desea realizar otro cálculo? (s/n)")
    if input(">> ").lower() == 's':
        main()
    else:
        print("Programa terminado.")

if __name__ == "__main__":
    main()