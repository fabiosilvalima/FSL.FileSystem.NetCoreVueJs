const vm = new Vue(
    {
        el: '#app',
        data: () => ({
            active: [],
            apiUrl: 'http://localhost:59615/filesystem',
            directory: null,
            searchTerm: null,
            items: [],
            showLoading: false,
            snackbar: false
        }),
        computed: {
            selected() {
                if (!this.active.length)
                    return undefined;

                return this.active.length > 0 ? this.active[0] : [];

            },
            quantityDirectories() {
                return this.items.length;
            },
            hasItems() {
                return this.quantityDirectories > 0;
            }
        },
        methods: {
            checkDirectoryExists(dir) {
                this.showLoading = !this.showLoading;
                axios.get(`${this.apiUrl}/check-directory?fullName=${dir}`)
                    .then(async ({ data }) => {
                        if (data) {
                            if (this.directory) {
                                const items = await this.fetchData(this.directory);
                                this.items = items;
                            }
                        } else {
                            this.items = [];
                            this.snackbar = true;
                        }
                    }).finally(() => this.showLoading = !this.showLoading);
            },
            fetchData(dir) {
                return new Promise((resolve, reject) => {
                    axios.get(`${this.apiUrl}?fullName=${dir}`)
                        .then(({ data }) => {
                            const items = this.resolverItems(data);
                            resolve(items);
                        })
                        .catch(function (error) {
                            reject(error);
                        });
                });
            },
            async fetchChildrens(item) {
                const items = await this.fetchData(item.id);
                item.children = items;
            },
            resolverItems(items) {
                return items.map((item) => {
                    if (item.hasChilds) {
                        item.children = [];
                        item.icon = this.getIconFromExtension(item.extension);
                    } else {
                        item.icon = this.getIconFromExtension(item.extension);
                    }
                    return item;
                });
            },
            getIconFromExtension(extension) {
                switch (extension) {
                    case '.rar': return 'far fa-file-archive';
                    case '.zip': return 'far fa-file-archive';
                    case '.pdf': return 'far fa-file-pdf';
                    case '.docx': return 'far fa-file-word';
                    case '.doc': return 'far fa-file-word';
                    case '.xlsx': return 'far fa-file-excel';
                    case '.xls': return 'far fa-file-excel';
                    case '.html': return "fab fa-html5";
                    case '.cs': return "fab fa-microsoft";
                    case '.sln': return "fab fa-microsoft";
                    case '.ts': return 'fab fa-js';
                    case '.json': return 'fas fa-cogs';
                    case '.js': return 'fab fa-js';
                    case '.cshtml': return "fab fa-html5";
                    case '.csproj': return 'file-code';
                    case '.dll': return 'file-fill';
                    case '.bmp': return 'far fa-file-image';
                    case '.png': return 'far fa-file-image';
                    case '.gif': return 'far fa-file-image';
                    case '.jpg': return 'far fa-file-image';
                    case '.jpeg': return 'far fa-file-image';
                    default: extension = 'far fa-file';
                }
                return extension;
            }
        }
    });