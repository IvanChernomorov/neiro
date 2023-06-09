testData = [2 1 0; 1 0 -1];

trainData = [];
numPoints = 10; 

trainData = vertcat(trainData, [2, 1] + rand(numPoints, 2) * 0.5 - 0.3);
trainData = vertcat(trainData, [1, 0] + rand(numPoints, 2) * 0.5 - 0.3);
trainData = vertcat(trainData, [0, -1] + rand(numPoints, 2) * 0.5 - 0.3);
trainData = vertcat(trainData, [2, -2] + rand(numPoints, 2) * 0.5 - 0.3);

figure;
hold on;
xlabel('X');
ylabel('Y');
title('Обучающая выборка');
plot(trainData(1:10,1),trainData(1:10,2),'og');
plot(trainData(11:20,1),trainData(11:20,2),'ob');
plot(trainData(21:30,1),trainData(21:30,2),'or');
plot(trainData(31:40,1),trainData(31:40,2),'oy');
grid on
hold off 



net = selforgmap([2 2]);
net = train(net, trainData');
outputs = sim(net, testData);
disp(outputs)



