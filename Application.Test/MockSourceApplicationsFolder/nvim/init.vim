" General_settings:
" Sets how many lines of history VIM has to remember
set history=1000
" Enable filetype plugins
filetype plugin on
filetype indent on
" Set to auto read when a file is changed from the outside
set autoread
let mapleader = " "
let maplocalleader = " "
" let $LANG='en'  " Or else it changes locale for child shell (:!locale)
set langmenu=en
"if !exists('g:syntax_on') | syntax enable | endif
set encoding=utf8

call plug#begin('~/AppData/Local/nvim/autoload/plugged')

    " File Explorer
    "Plug 'preservim/nerdtree' | 
     "           \ Plug 'Xuyuanp/nerdtree-git-plugin' | 
     "           \ Plug 'ryanoasis/vim-devicons'
    " Auto pairs for '(' '[' '{'
    "Plug 'jiangmiao/auto-pairs'
    " Theme
    Plug 'joshdick/onedark.vim'
    "Plug 'vim-airline/vim-airline'
    "Plug 'vim-airline/vim-airline-themes'

    " Omnishaarp/ Language plugins
    Plug 'OmniSharp/omnisharp-vim'
    " Linting/error highlighting
    Plug 'dense-analysis/ale'
    Plug 'Shougo/deoplete.nvim', { 'do': ':UpdateRemotePlugins'  }
    " Autocompletion
    Plug 'prabirshrestha/asyncomplete.vim'
    Plug 'sirver/ultisnips'
    """"""""""""""""""""""""""""""""""""""""""""""
    " Markdown
    Plug 'iamcco/markdown-preview.nvim', { 'do': 'cd app && yarn install'  }
    " Git
    Plug 'airblade/vim-gitgutter'
    " Start page
    Plug 'mhinz/vim-startify'
    " goyo distraction free mode
    Plug 'junegunn/goyo.vim'
    " Indent guides
    "Plug 'Yggdroot/indentLine'

    " Search_and_find:
    Plug 'junegunn/fzf', { 'do': { -> fzf#install()  }  }    
    Plug 'junegunn/fzf.vim'
    Plug 'mbbill/undotree'
call plug#end()


" Settings: {{{
"--------------

" WildMenu:
" Turn on the Wild menu
set wildmenu
" Ignore compiled files
set wildignore=*.o,*~,*.pyc
if has("win16") || has("win32")
    set wildignore+=.git\*,.hg\*,.svn\*
else
    set wildignore+=*/.git/*,*/.hg/*,*/.svn/*,*/.DS_Store
endif




" Buffers_and_Windows:

" Height of the command bar
set showcmd
set cmdheight=2
" A buffer becomes hidden when it is abandoned
set hidden
" New window goes down. For preview-window to pop up at bottom.
set splitbelow
" New window goes right.
set splitright
" Preview window height
set previewheight=5
" Turn bell off
set belloff=all                
" Having longer updatetime (default is 4000 ms = 4 s) leads to noticeable delays and poor user experience
set updatetime=300             




"  Files_backups_and_undo:

" Turn backup off, since most stuff is in SVN, git et.c anyway...
set nobackup
set nowritebackup
set noswapfile



" Text_tab_and_indent_related:

" Configure backspace so it acts as it should act
set backspace=eol,start,indent
"Always show current position
set ruler
" Highlight search results
set hlsearch
" Makes search act like search in modern browsers
set incsearch 
" Show matching brackets when text indicator is over them
set showmatch 
" How many tenths of a second to blink when matching brackets
set matchtime=2
" Use spaces instead of tabs
set expandtab
" Be smart when using tabs ;)
set smarttab
" 1 tab == 4 spaces
set shiftwidth=4
set tabstop=4
set autoindent
set smartindent
set wrap "Wrap lines
set clipboard=unnamedplus          
set colorcolumn=80
set textwidth=79
set signcolumn=yes
set number                              
set relativenumber                      




" Saving:

" Auto save when buffer lose focus
autocmd FocusLost,BufLeave * silent! wa
" Save on buffer change
set autowrite 


"  Colors_And_Fonts: {{{
"Enable syntax highlighting
syntax enable 

"Use truecolor in the terminal, when it is supported
if has('termguicolors')
set termguicolors
endif

autocmd ColorScheme * highlight Normal ctermbg=NONE guibg=NONE
colorscheme onedark


" Vim_airline:
"let g:airline_powerline_fonts = 1
"let g:airline_theme='simple'


" ALE: 
let g:ale_sign_error = 'e'
let g:ale_sign_warning = 'w'
let g:ale_sign_info = 'i'
let g:ale_sign_style_error = 'se'
let g:ale_sign_style_warning = 'sw'

"let g:ale_completion_enabled=0

"" Use ALE's function for omnicompletion.
"set omnifunc=ale#completion#OmniFunc

let g:ale_linters = {
     \ 'cs': ['omnisharp', 'mcs']
     \}

" Asyncomplete:
let g:asyncomplete_auto_popup = 1
let g:asyncomplete_auto_completeopt = 0

" OmniSharp: 
set completeopt=menuone,noinsert,noselect,preview
autocmd! CompleteDone * if pumvisible() == 0 | pclose | endif
" Update semantic highlighting on BufEnter and InsertLeave
let g:OmniSharp_highlight_types = 3
"show loading message
let g:OmniSharp_server_display_loading = 1
" Autoselect sln file
let g:OmniSharp_autoselect_existing_sln = 1

let g:omnicomplete_fetch_full_documentation = 1
let g:OmniSharp_want_snippet = 1
let g:OmniSharp_popup_options = {
            \ 'winblend': 30,
            \ 'winhl': 'Float'
            \}
let g:OmniSharp_selector_ui = 'fzf'
let g:OmniSharp_selector_findusages = 'fzf'
augroup omnisharp_commands
  autocmd!
  autocmd FileType cs nmap <silent> <buffer> gd <Plug>(omnisharp_go_to_definition) 
  autocmd FileType cs nmap <silent> <buffer> <Leader>ocf <Plug>(omnisharp_code_format)
  autocmd FileType cs nmap <silent> <buffer> <Leader>ofu <Plug>(omnisharp_fix_usings)
  autocmd FileType cs nmap <silent> <buffer> <Leader>osfu <Plug>(omnisharp_find_usages)
  autocmd FileType cs nmap <silent> <buffer> <Leader>osfi <Plug>(omnisharp_find_implementations)
  autocmd FileType cs nmap <silent> <buffer> <Leader>ospd <Plug>(omnisharp_preview_definition)
  autocmd FileType cs nmap <silent> <buffer> <Leader>ospi <Plug>(omnisharp_preview_implementations)
  autocmd FileType cs nmap <silent> <buffer> <Leader>ost <Plug>(omnisharp_type_lookup)
  autocmd FileType cs nmap <silent> <buffer> <Leader>osd <Plug>(omnisharp_documentation)
  autocmd FileType cs nmap <silent> <buffer> <Leader>orn <Plug>(omnisharp_rename)

augroup END


" Indent Guides: 
"let g:indentLine_char = '▏'
"let g:indentLine_char_list = ['|', '¦', '┆', '┊']

"let g:indent_guides_auto_colors = 1
"let g:indentLine_fileTypeExclude = [
"      \'defx',
"      \'markdown',
"      \'denite',
"      \'startify',
"      \'tagbar',
"      \'vista_kind',
"      \'vista',
"      \'vim'
"      \]

"NERDTree:
"let g:NERDTreeDirArrowExpandable = '-'
"let g:NERDTreeDirArrowCollapsible = '|'
"let NERDTreeShowLineNumbers=1

" Remaps: 
" Toggle NERDTree with <ctrl + n>
"nmap <C-d> :NERDTreeToggle<CR> 

"Navigate when splitted windows"
nnoremap <C-h> <C-W>h
nnoremap <C-j> <C-W>j
nnoremap <C-k> <C-W>k
nnoremap <C-l> <C-W>l

" Functions: 

" function open powershell
function! OpenTerminal()
    split term://pwsh
    resize 20
endfunction
nnoremap <C-n>  :call OpenTerminal()<CR>
tnoremap <Esc> <C-\><C-n>               " Enter normal mode in terminal
