T = [-1 +1 -1 +1 -1; 
            +1 +1 +1 -1 -1; 
            -1 -1 -1 +1 +1; 
            -1 +1 -1 +1 -1; 
            +1 +1 +1 -1 -1] ;

net = newhop(T);

random_data = rands(5, 1);
initial_state = random_data;

updated_state = sim(net, [1 20], [], initial_state);

disp('Исходные данные:');
disp(random_data');
for i = 1:20
    disp('Обновленное состояние:');
    disp(updated_state{i}');
    if(ismember(updated_state{i}, T, 'legacy'))
        disp(['Достигнуто устойчивое состояние за ', num2str(i), ' шагов']);
        break;
    end
end
