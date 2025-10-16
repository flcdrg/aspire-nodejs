import express from "express";
const app = express();
const port = process.env.PORT || 3000;

app.get("/", (req, res) => {
  res.send("Hello World!");
});

app.get("/api", (req, res) => {
  // Get name from query parameters
  const name = req.query.name;
  if (!name) {
    res.sendStatus(404);
    return;
  }
  res.send(`Hello ${name}!`);
});

app.listen(port, () => {
  console.log(`Server is running at http://localhost:${port}`);
});
