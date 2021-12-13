var colors = [];
colors[0] = 'alert alert-primary';
colors[1] = 'alert alert-secondary';
colors[2] = 'alert alert-success';
colors[3] = 'alert alert-danger';
colors[4] = 'alert alert-warning';
colors[5] = 'alert alert-danger';
colors[6] = 'alert alert-light';
colors[7] = 'alert alert-dark';

function getAlertStyle() {
    var index = Math.floor(Math.random() * 8);

    return colors[index];
}