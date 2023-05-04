% количество точек
L=700;
% генерация значений аргумента X
X=1:(9/L):10;
% расчет точек функции, зашумленной линейным шумом
Noise=0.2*rand(1,length(X));
Y=log(X).*cos(3*X-15)+Noise; 

% визуализируем обучающую выборку
plot(X,Y,'LineStyle','none','Marker','.','MarkerSize',5, 'Color', 'r');
% создаем ИНС
Net = feedforwardnet(25,'traingdx');
Net = configure(Net, X, Y);
% обучаем ИНС
Net=train(Net,X,Y);
hold on;
% Тестируем ИНС на интервале шире, чем обучающая выборка
X_rez=-5:0.01:15;
Y_rez = sim(Net, X_rez);
% визуализируем результаты аппроксимации
plot(X_rez,Y_rez,'LineStyle','none','Marker','.','MarkerSize',15);
hold off; 