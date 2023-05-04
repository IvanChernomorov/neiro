% ���������� �����
L=700;
% ��������� �������� ��������� X
X=1:(9/L):10;
% ������ ����� �������, ����������� �������� �����
Noise=0.2*rand(1,length(X));
Y=log(X).*cos(3*X-15)+Noise; 

% ������������� ��������� �������
plot(X,Y,'LineStyle','none','Marker','.','MarkerSize',5, 'Color', 'r');
% ������� ���
Net = feedforwardnet(25,'traingdx');
Net = configure(Net, X, Y);
% ������� ���
Net=train(Net,X,Y);
hold on;
% ��������� ��� �� ��������� ����, ��� ��������� �������
X_rez=-5:0.01:15;
Y_rez = sim(Net, X_rez);
% ������������� ���������� �������������
plot(X_rez,Y_rez,'LineStyle','none','Marker','.','MarkerSize',15);
hold off; 