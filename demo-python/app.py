from flask import Flask, jsonify
from datetime import datetime, timedelta
import random

app = Flask(__name__)

summaries = [
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
]

@app.route('/weatherforecast')
def get_weather_forecast():
    forecast = []
    for index in range(1, 6):
        date = (datetime.now() + timedelta(days=index)).date()
        temperature_c = random.randint(-20, 55)
        summary = random.choice(summaries)
        forecast.append({
            'Date': date.isoformat(),
            'TemperatureC': temperature_c,
            'Summary': summary
        })
    return jsonify(forecast)

@app.route('/weatherforecast/sorted')
def get_sorted_weather_forecast():
    forecast = []
    for index in range(1, 6):
        date = (datetime.now() + timedelta(days=index)).date()
        temperature_c = random.randint(-20, 55)
        summary = random.choice(summaries)
        forecast.append({
            'Date': date.isoformat(),
            'TemperatureC': temperature_c,
            'Summary': summary
        })
    forecast.sort(key=lambda f: f['TemperatureC'])
    return jsonify(forecast)

if __name__ == '__main__':
    app.run()