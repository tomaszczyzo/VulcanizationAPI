const PROXY_CONFIG = [
  {
    context: [
      "/api/vulcanization",
    ],
    target: "https://localhost:4200",
    secure: true
  }
]

module.exports = PROXY_CONFIG;
