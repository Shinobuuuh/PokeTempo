const express = require('express');
const bodyParser = require('body-parser');
const superagent = require('superagent');
const crypto = require('crypto');

const app = express();

app.set('view engine', 'ejs');
app.use(bodyParser.urlencoded());
app.use(express.static(__dirname + '/public'));

app.get('/', function (req, res) {
  res.sendFile(__dirname + '/views/index.html')
});

app.post('/search', async function (req, res) {
  try {
    res.set({ 'content-type': 'application/x-www-form-urlencoded; charset=ascii' });
    climaResponse = await superagent
      .post('https://api.openweathermap.org/data/2.5/weather?q=' + req.body.cidade + '&appid=76bb83bd2478a0b030682c57b4cefda2&units=metric&lang=pt_br')

    if (climaResponse.body.weather.main == 'Rain') {
      pokemon_tipo = "eletric"
    } else {
      if (climaResponse.body.main.temp < 5) {
        pokemon_tipo = "ice"
      } else {
          if (climaResponse.body.main.temp >= 5 && climaResponse.body.main.temp < 10) {
            pokemon_tipo = "water"
          } else {
          if (climaResponse.body.main.temp >= 10 && climaResponse.body.main.temp < 15) {
            pokemon_tipo = "grass"
          } else {
            if (climaResponse.body.main.temp >= 15 && climaResponse.body.main.temp < 21) {
              pokemon_tipo = "ground"
            } else {
              if (climaResponse.body.main.temp >= 21 && climaResponse.body.main.temp < 27) {
                pokemon_tipo = "bug"
              } else {
                if (climaResponse.body.main.temp >= 27 && climaResponse.body.main.temp < 33) {
                  pokemon_tipo = "rock"
                } else {
                  if (climaResponse.body.main.temp >= 33) {
                    pokemon_tipo = "fire"
                  } else {
                    pokemon_tipo = "normal"
                  }
                }
              }
            }
          }
        }
      }
    }

    pokemonsRes = await superagent.get('https://pokeapi.co/api/v2/type/' + pokemon_tipo);

    res.redirect('/?cidade=' + req.body.cidade + '&pokemon=' + pokemonsRes.body.pokemon[3].pokemon.name + '&pokemon_tipo=' + pokemon_tipo + '&temperatura=' + climaResponse.body.main.temp + '&chuva=' + climaResponse.body.weather[0].description + '&palavra_chave=' + encrypt(req.connection.remoteAddress));

  } catch (e) {
    res.redirect('/error')
  }
});

app.get('/error', function (req, res) {
  res.send('Internal Server Error')
});

app.listen(process.env.PORT, function () {
  console.log('Listening on port ' + process.env.PORT + '!');
});

function encrypt(text) {
  if (!process.env.SECRET_KEY) return '';

  var cipher = crypto.createCipher('aes-256-ctr', process.env.SECRET_KEY)
  var crypted = cipher.update(text, 'utf8', 'hex')
  crypted += cipher.final('hex');
  return crypted;
}

function decrypt(text){
  var decipher = crypto.createDecipher('aes-256-ctr', process.env.SECRET_KEY)
  var dec = decipher.update(text, 'hex', 'utf8')
  dec += decipher.final('utf8');
  return dec;
}
