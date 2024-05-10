# CoreBlog
Murat Yücedağ Eğitim [Vidyo serisi](https://www.youtube.com/playlist?list=PLKnjBHu2xXNNkinaVhPqPZG0ubaLN63ci) Blog sayfa projesi
<br>
<br>
Projeye bitti

#### Canlı versiyon aktif => <a href="https://blog.karunlander.net" target="_blank">blog.karunlander.net/</a> 

### Ornek Docker kullanimi
```bash
docker build -t blogsite-1 .
docker run -d --restart unless-stopped -p 5011:5011 --name blog-container blogsite-1:latest
```
